import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../../models/Category'; 
import { Result } from '../../models/Result';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {
  private apiUrl = 'https://localhost:7266/api/category';

  constructor(private http: HttpClient) {}

  getCategories(): Observable<Result<Category[]>> {
    return this.http.get<Result<Category[]>>(`${this.apiUrl}/getcategories`);
  }

  getCategoriesByFileId(id: number): Observable<Result<Category[]>> {
    return this.http.get<Result<Category[]>>(`${this.apiUrl}/getcategories/${id}`);
  }
}
