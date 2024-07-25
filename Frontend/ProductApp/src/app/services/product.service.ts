import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';

const baseUrl = 'https://localhost:44325/api/Product';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(`${baseUrl}/All`);
  }

  get(id: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${baseUrl}/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(`${baseUrl}/Add`, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${baseUrl}/${id}/Update`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}/Delete`);
  }

  findByProductName(name: any): Observable<Product[]> {
    return this.http.get<Product[]>(`${baseUrl}?productName=${name}`);
  }
}
