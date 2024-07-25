import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { UpdateProductComponent } from './components/update-product/update-product.component';
import { AddProductComponent } from './components/add-product/add-product.component';

const routes: Routes = [
  {path: '', redirectTo: 'products', pathMatch: 'full'},
  {path:'products', component: ProductListComponent},
  {path:'products/update/:id', component:UpdateProductComponent},
  {path:'products/add', component: AddProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
