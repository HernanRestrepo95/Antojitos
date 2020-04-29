import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { ShowcaseComponent } from './showcase/showcase.component';
import { CartComponent } from './cart/cart.component';
import { ProductThumbnailComponent } from './product-thumbnail/product-thumbnail.component';
import { SortFiltersComponent } from './sort-filters/sort-filters.component';
import { ClientComponent } from './client/client.component'

import { DataService } from './data.service';
import { CartService } from './cart.service';

@NgModule({
  declarations: [
    AppComponent,
    ShowcaseComponent,
    CartComponent,
    ProductThumbnailComponent,
    SortFiltersComponent,
    ClientComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    JsonpModule
  ],
  providers: [
    DataService,
    CartService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
