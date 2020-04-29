import { Injectable } from '@angular/core';
import { Product } from './shared/product.model';
import { Subject } from 'rxjs/Subject';
import Swal from 'sweetalert2';


@Injectable()
export class CartService {

  products: any[] = [];
  cartTotal = 0;

  private productAddedSource = new Subject<any>();


  productAdded$ = this.productAddedSource.asObservable();

  constructor() { }

  addProductToCart(product) {
    let exists = false;
    const parsedPrice = parseFloat(product.ValorUnidad.toString().replace(/\./g, '').replace(',', '.'));    
    // Search this product on the cart and increment the quantity
    this.products = this.products.map(_product => {
      if (_product.product.IdProducto === product.IdProducto) {
        exists = true;
        if(_product.quantity +1 > product.Stock){
          Swal.fire('Cantidad excedida', "Antojitos", 'error');
        }else{   
          _product.quantity++; 
          this.cartTotal += parsedPrice;         
        }        
      }
      return _product;
    });
    // Add a new product to the cart if it's a new product
    if (!exists) {
      product.parsedPrice = parsedPrice;
      this.cartTotal += parsedPrice;
      this.products.push({
        product: product,
        quantity: 1
      });
    }

    this.productAddedSource.next({ products: this.products, cartTotal: this.cartTotal });
  }

  deleteProductFromCart(product) {
    this.products = this.products.filter(_product => {
      if (_product.product.IdProducto === product.IdProducto) {
        this.cartTotal -= _product.product.parsedPrice * _product.quantity;
        return false;
      }
      return true;
     });
    this.productAddedSource.next({ products: this.products, cartTotal: this.cartTotal });
  }


  flushCart() {
    this.products = [];
    this.cartTotal = 0;
    this.productAddedSource.next({ products: this.products, cartTotal: this.cartTotal });
  }
}
