import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap } from 'rxjs';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { UploadResponse } from 'src/app/models/common/upload-response';
import { Sport } from 'src/app/models/data/sport';

@Injectable({
  providedIn: 'root'
})
export class SportsService {
  constructor(
    private http:HttpClient
  ) { }
  

  getSports(): Observable<Sport[]> {
    return this.http.get<Sport[]>(`${apiBaseUrl}/api/Sports`)    
  }

  getSportsWithPlayers(): Observable<Sport[]> {
    return this.http.get<Sport[]>(`${apiBaseUrl}/api/Sports/Players/Include`)    
  }
  getSportsWithTeams(): Observable<Sport[]> {
    return this.http.get<Sport[]>(`${apiBaseUrl}/api/Sports/Teams/Include`)    
  }
  getSportsWithSelectionPanel(): Observable<Sport[]> {
    return this.http.get<Sport[]>(`${apiBaseUrl}/api/Sports/SelectionPanel/Include`)    
  }
  getSportsWithManagerById(id:number): Observable<Sport[]>
  {
    return this.http.get<Sport[]>(`${apiBaseUrl}/api/Sports/Manager/Include/${id}`)
  }
  getSportsWithSelectionPanelById(id:number): Observable<Sport[]>
  {
    return this.http.get<Sport[]>(`${apiBaseUrl}/api/Sports/SelectionPanel/${id}`)
  }

  create(data:Sport):Observable<Sport>{
    console.log(data)
    return this.http.post<Sport>(`${apiBaseUrl}/api/Sports`, data);
  }
  update(data: Sport): Observable<any> {
    console.log("Update Payload:", data); // Log the payload
  
    return this.http.put<Sport>(`${apiBaseUrl}/api/Sports/${data.sportId}`, data);
  }
  
  getById(id: number): Observable<Sport> {
    return this.http.get<Sport>(`${apiBaseUrl}/api/Sports/${id}`)
  }
  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/Sports/${id}`);
  }
  uploadImage(id: number, f: File): Observable<UploadResponse> {
    const formData = new FormData();
    formData.append('file', f);
    console.log(f);
    return this.http.post<UploadResponse>(`${apiBaseUrl}/api/Sports/Upload/${id}`, formData);
  }
}