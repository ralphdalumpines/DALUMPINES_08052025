import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/Category'; 

@Injectable({
  providedIn: 'root'
})

export class CategoryService {
  private apiUrl = '/api/categories';

  constructor(private http: HttpClient) {}

  getCategories(id: number): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.apiUrl}/getvideo/${id}`);
  }
}
