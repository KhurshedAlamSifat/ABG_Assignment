import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { UpdateProductComponent } from './components/update-product/update-product.component';
import { ProductListComponent } from './components/product-list/product-list.component';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
// import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
  declarations: [
    AppComponent,
    AddProductComponent,
    UpdateProductComponent,
    ProductListComponent,
    // ProductDetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
