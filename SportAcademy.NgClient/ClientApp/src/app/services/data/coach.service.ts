import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core"
import { Observable } from "rxjs"
import { UploadResponse } from "src/app/models/common/upload-response"
import { Coach } from "src/app/models/data/coach"
import { apiBaseUrl } from "src/app/shared/app-constants"

@Injectable({
    providedIn: 'root'
  })
  export class CoachService {
    constructor(
      private http:HttpClient
    ) { }
    
  
    getCoaches(): Observable<Coach[]> {
      return this.http.get<Coach[]>(`${apiBaseUrl}/api/Coaches`)    
    }
  
    getCoachWithSelectionPanel(): Observable<Coach[]> {
      return this.http.get<Coach[]>(`${apiBaseUrl}/api/Coaches/SelectionPanel/Include`)    
    }
    getCoachesWithSelectionPanelById(id:number): Observable<Coach[]>
    {
      return this.http.get<Coach[]>(`${apiBaseUrl}/api/Coaches/SelectionPanel/Include/${id}`)
    }
    getCoachesBySelectionPanelId(selectionPanelId: number): Observable<Coach[]> {
      const url = `${apiBaseUrl}/Coach/SelectionPanel/${selectionPanelId}`;
      return this.http.get<Coach[]>(url);
    }
  
    create(data:Coach):Observable<Coach>{
      console.log(data)
      return this.http.post<Coach>(`${apiBaseUrl}/api/Coaches`, data);
    }
    update(data: Coach): Observable<any> {
      return this.http.put<Coach>(`${apiBaseUrl}/api/Coaches/${data.coachId}`, data);
    }
    getById(id: number): Observable<Coach> {
      return this.http.get<Coach>(`${apiBaseUrl}/api/Coaches/${id}`)
    }
    delete(id: number): Observable<any> {
      return this.http.delete<any>(`${apiBaseUrl}/api/Coaches/${id}`);
    }
    uploadImage(id: number, f: File): Observable<UploadResponse> {
      const formData = new FormData();
      formData.append('file', f);
      console.log(f);
      return this.http.post<UploadResponse>(`${apiBaseUrl}/api/Coaches/Upload/${id}`, formData);
    }
  }