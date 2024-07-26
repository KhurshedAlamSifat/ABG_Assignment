import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent implements OnInit {
  @Input() viewMode = false;
  @Input() currentProduct: Product = {
    productName: '',
    productDescription: '',
    productPrice: 0,
    productQuantity: 0,
  };
  message = '';

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (!this.viewMode) {
      this.getProduct(this.route.snapshot.params['id']);
    }
  }

  getProduct(id: number): void {
    this.productService.get(id).subscribe({
      next: (data) => {
        this.currentProduct = data;
        console.log(data);
      },
      error: (err) => {
        console.error('Error:', err);
      },
    });
  }

  updateProduct(): void {
    this.message = '';

    this.productService
      .update(this.currentProduct.productId, this.currentProduct)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = res.message
            ? res.message
            : 'Product was updated successfully!';
        },
        error: (e) => console.error(e),
      });
  }

  deleteProduct(): void {
    this.productService.delete(this.currentProduct.productId).subscribe({
      next: (res) => {
        console.log(res);
        this.router.navigate(['/products']);
      },
      error: (e) => console.error(e),
    });
  }
}
