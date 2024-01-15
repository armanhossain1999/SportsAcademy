import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap } from 'rxjs';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { UploadResponse } from 'src/app/models/common/upload-response';
import { Team } from 'src/app/models/data/team';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  constructor(
    private http:HttpClient
  ) { }
  

  getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(`${apiBaseUrl}/api/Teams`)    
  }

  getTeamsWithPlayers(): Observable<Team[]> {
    return this.http.get<Team[]>(`${apiBaseUrl}/api/Teams/Players/Include`)    
  }
  getTeamsWithSports(): Observable<Team[]> {
    return this.http.get<Team[]>(`${apiBaseUrl}/api/Teams/Sports/Include`)    
  }
  getTeamsWithSelectionPanel(): Observable<Team[]> {
    return this.http.get<Team[]>(`${apiBaseUrl}/api/Teams/SelectionPanel/Include`)    
  }
  getTeamsWithManagerById(id:number): Observable<Team[]>
  {
    return this.http.get<Team[]>(`${apiBaseUrl}/api/Teams/Manager/Include/${id}`)
  }
  getTeamsWithSelectionPanelById(id:number): Observable<Team[]>
  {
    return this.http.get<Team[]>(`${apiBaseUrl}/api/Teams/SelectionPanel/${id}`)
  }

  create(data:Team):Observable<Team>{
    console.log(data)
    return this.http.post<Team>(`${apiBaseUrl}/api/Teams`, data);
  }
  update(data: Team): Observable<any> {
    return this.http.put<Team>(`${apiBaseUrl}/api/Teams/${data.teamId}`, data);
  }
  getById(id: number): Observable<Team> {
    return this.http.get<Team>(`${apiBaseUrl}/api/Teams/${id}`)
  }
  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/Teams/${id}`);
  }
  uploadImage(id: number, f: File): Observable<UploadResponse> {
    const formData = new FormData();
    formData.append('file', f);
    console.log(f);
    return this.http.post<UploadResponse>(`${apiBaseUrl}/api/Teams/Upload/${id}`, formData);
  }
}