import { Component } from '@angular/core';
import { Product } from '../../models/product.model';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent {
product: Product={
  productName:'',
  productDescription:'',
  productPrice: 0,
  productQuantity: 0,
};
submitted=false;

constructor(private productService: ProductService){}

saveProduct(): void{
  const data = {
    productName: this.product.productName,
    productDescription: this.product.productDescription,
    productPrice: this.product.productPrice,
    productQuantity: this.product.productQuantity,
  };

  this.productService.create(data).subscribe({
    next: (res) => {
      console.log(res);
      this.submitted = true;
    },
    error: (err) => {
      console.error('Error:', err);
    },
  });
}

newProduct(): void{
  this.submitted = false;
  this.product={
    productName: '',
    productDescription: '',
    productPrice: 0,
    productQuantity: 0,
  };
}
}
