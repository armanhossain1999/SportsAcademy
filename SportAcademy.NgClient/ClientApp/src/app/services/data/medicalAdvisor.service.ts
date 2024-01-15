import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core"
import { Observable } from "rxjs"
import { UploadResponse } from "src/app/models/common/upload-response"
import { MedicalAdvisor } from "src/app/models/data/medicaladvisor"
import { apiBaseUrl } from "src/app/shared/app-constants"

@Injectable({
    providedIn: 'root'
  })
  export class MedicalAdvisorService {
    constructor(
      private http:HttpClient
    ) { }
    
  
    getMedicalAdvisors(): Observable<MedicalAdvisor[]> {
      return this.http.get<MedicalAdvisor[]>(`${apiBaseUrl}/api/MedicalAdvisors`)    
    }
  
    getMedicalAdvisorWithSelectionPanels(): Observable<MedicalAdvisor[]> {
      return this.http.get<MedicalAdvisor[]>(`${apiBaseUrl}/api/MedicalAdvisors/SelectionPanels/Include`)    
    }
  
    create(data:MedicalAdvisor):Observable<MedicalAdvisor>{
      console.log(data)
      return this.http.post<MedicalAdvisor>(`${apiBaseUrl}/api/MedicalAdvisors`, data);
    }
    update(data: MedicalAdvisor): Observable<any> {
      return this.http.put<MedicalAdvisor>(`${apiBaseUrl}/api/MedicalAdvisors/${data.medicalAdvisorId}`, data);
    }
    getById(id: number): Observable<MedicalAdvisor> {
      return this.http.get<MedicalAdvisor>(`${apiBaseUrl}/api/MedicalAdvisors/${id}`)
    }
    delete(id: number): Observable<any> {
      return this.http.delete<any>(`${apiBaseUrl}/api/MedicalAdvisors/${id}`);
    }
    uploadImage(id: number, f: File): Observable<UploadResponse> {
      const formData = new FormData();
      formData.append('file', f);
      console.log(f);
      return this.http.post<UploadResponse>(`${apiBaseUrl}/api/MedicalAdvisors/Upload/${id}`, formData);
    }
  }