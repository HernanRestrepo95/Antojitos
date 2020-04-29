import { Component, OnInit } from '@angular/core';
import { Product } from './shared/product.model';
import { DataService } from './data.service';
import { CartService } from './cart.service';
import { AfterViewInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  products: Product[];

  currentSorting: string;

  sortFilters: any[] = [
    { name: 'Nombre (A a Z)', value: 'name' },
    { name: 'Precio (Bajo a Alto)', value: 'priceAsc' },
    { name: 'Precio (Alto a Bajo)', value: 'priceDes' }
  ];

  originalData: any = [];

  constructor(private dataService: DataService, private cartService: CartService) {  }

  ngOnInit() {
    this.getProducts();
  }

  getProducts(){
    this.dataService.getProducts().subscribe(data => {
      this.originalData = data;
      // Make a deep copy of the original data to keep it immutable
      this.products = this.originalData.slice(0);
      this.sortProducts('name');
      this.cartService.flushCart();
    });
  }

  sortProducts(criteria) {
    // console.log('sorting ' + this.products.length + ' products')
    this.products.sort((a, b) => {
      const priceComparison = parseFloat(a.ValorUnidad.toString().replace(/\./g, '')
      .replace(',', '.')) - parseFloat(b.ValorUnidad.toString().replace(/\./g, '').replace(',', '.'));
      if (criteria === 'priceDes') {
        return -priceComparison;
      } else if (criteria === 'priceAsc') {
        return  priceComparison;
      } else if (criteria === 'name') {
        const nameA = a.Nombre.toLowerCase(), nameB = b.Nombre.toLowerCase();
        if (nameA < nameB) {
          return -1;
        }
        if (nameA > nameB) {
          return 1;
        }
        return 0;
      } else {
        // Keep the same order in case of any unexpected sort criteria
        return -1;
      }
    });
    this.currentSorting = criteria;
  }
}
