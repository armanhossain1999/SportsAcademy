import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core"
import { Observable } from "rxjs"
import { UploadResponse } from "src/app/models/common/upload-response"
import { CoachSpecializaton } from "src/app/models/data/coachSpecialization"
import { apiBaseUrl } from "src/app/shared/app-constants"

@Injectable({
    providedIn: 'root'
  })
  export class CoachSpecializatonService {
    constructor(
      private http:HttpClient
    ) { }
    
  
    getCoachSpecializatons(): Observable<CoachSpecializaton[]> {
      return this.http.get<CoachSpecializaton[]>(`${apiBaseUrl}/api/CoachSpecializations`)    
    }
  
    getCoachSpecializatonWithSelectionPanel(): Observable<CoachSpecializaton[]> {
      return this.http.get<CoachSpecializaton[]>(`${apiBaseUrl}/api/CoachSpecializations/SelectionPanel/Include`)    
    }
  
    create(data:CoachSpecializaton):Observable<CoachSpecializaton>{
      console.log(data)
      return this.http.post<CoachSpecializaton>(`${apiBaseUrl}/api/CoachSpecializations`, data);
    }
    update(data: CoachSpecializaton): Observable<any> {
      return this.http.put<CoachSpecializaton>(`${apiBaseUrl}/api/CoachSpecializations/${data.coachSpecializationId}`, data);
    }
    getById(id: number): Observable<CoachSpecializaton> {
      return this.http.get<CoachSpecializaton>(`${apiBaseUrl}/api/CoachSpecializations/${id}`)
    }
    delete(id: number): Observable<any> {
      return this.http.delete<any>(`${apiBaseUrl}/api/CoachSpecializations/${id}`);
    }
  }