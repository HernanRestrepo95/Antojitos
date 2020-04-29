import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../shared/product.model';
import { CartService } from '../cart.service';
import { DataService } from '../data.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-product-thumbnail',
  templateUrl: './product-thumbnail.component.html',
  styleUrls: ['./product-thumbnail.component.scss']
})
export class ProductThumbnailComponent implements OnInit {

  @Input() product: Product;

  detailViewActive: boolean;

  constructor(private cartService: CartService, private dataService: DataService) {

  }

  ngOnInit() {
    this.detailViewActive = false;
  }

  onAddToCart() {
    var client = this.dataService.getSession();

    if(client != null && client.Identifiacion != null){
      this.cartService.addProductToCart(this.product);
    }else{
      Swal.fire('Ingrese un cliente', "Antojitos", 'error');
    }
  }

}
