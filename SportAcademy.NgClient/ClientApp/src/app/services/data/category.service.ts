import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap } from 'rxjs';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { UploadResponse } from 'src/app/models/common/upload-response';
import { Category } from 'src/app/models/data/category';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(
    private http:HttpClient
  ) { }
  

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${apiBaseUrl}/api/Categories`)    
  }

  getCategoriesWithPlayers(): Observable<Category[]> {
    return this.http.get<Category[]>(`${apiBaseUrl}/api/Categories/Players/Include`)    
  }
  getCategoriesWithPlayerById(id:number): Observable<Category[]>
  {
    return this.http.get<Category[]>(`${apiBaseUrl}/api/Categories/Player/Include/${id}`)
  }
  create(data:Category):Observable<Category>{
    console.log(data)
    return this.http.post<Category>(`${apiBaseUrl}/api/Categories`, data);
  }
  update(data: Category): Observable<any> {
    return this.http.put<Category>(`${apiBaseUrl}/api/Categories/${data.categoryId}`, data);
  }
  getById(id: number): Observable<Category> {
    return this.http.get<Category>(`${apiBaseUrl}/api/Categories/${id}`)
  }
  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/Categories/${id}`);
  }
}