import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product.model';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  currentProduct: Product = {};
  currentIndex = -1;
  productName = '';
  page: number = 1; // Current page number

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.retrieveProducts();
  }

  retrieveProducts(): void {
    this.productService.getAll().subscribe({
      next: (data) => {
        this.products = data;
        console.log(data);
      },
      error: (e) => console.error(e),
    });
  }

  setActiveProduct(product: Product, index: number): void {
    this.currentProduct = product;
    this.currentIndex = index;
  }

  searchProductName(): void {
    this.currentProduct = {};
    this.currentIndex = -1;

    this.productService.findByProductName(this.productName).subscribe({
      next: (data) => {
        this.products = data;
        this.page = 1; // Reset to the first page
        console.log(data);
      },
      error: (e) => console.error(e),
    });
  }
}
