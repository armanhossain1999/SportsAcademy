import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap } from 'rxjs';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { CricketFormat } from 'src/app/models/data/cricketFormat';

@Injectable({
  providedIn: 'root'
})
export class CricketFormatsService {
  constructor(
    private http:HttpClient
  ) { }
  

  getCricketFormats(): Observable<CricketFormat[]> {
    return this.http.get<CricketFormat[]>(`${apiBaseUrl}/api/CricketFormats`)    
  }

  create(data:CricketFormat):Observable<CricketFormat>{
    console.log(data)
    return this.http.post<CricketFormat>(`${apiBaseUrl}/api/CricketFormats`, data);
  }
  update(data: CricketFormat): Observable<any> {
    return this.http.put<CricketFormat>(`${apiBaseUrl}/api/CricketFormats/${data.cricketFormatId}`, data);
  }
  getById(id: number): Observable<CricketFormat> {
    return this.http.get<CricketFormat>(`${apiBaseUrl}/api/CricketFormats/${id}`)
  }
  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/CricketFormats/${id}`);
  }  
}