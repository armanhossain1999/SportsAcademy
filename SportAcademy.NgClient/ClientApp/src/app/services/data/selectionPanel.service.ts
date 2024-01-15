import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core"
import { Observable } from "rxjs"
import { UploadResponse } from "src/app/models/common/upload-response"
import { SelectionPanel } from "src/app/models/data/selectionPanel"
import { apiBaseUrl } from "src/app/shared/app-constants"

@Injectable({
    providedIn: 'root'
  })
  export class SelectionPanelService {
    constructor(
      private http:HttpClient
    ) { }
    
  
    getSelectionPanels(): Observable<SelectionPanel[]> {
      return this.http.get<SelectionPanel[]>(`${apiBaseUrl}/api/SelectionPanels`)    
    }
    getSelectionPanelsWithEvents(): Observable<SelectionPanel[]> {
      return this.http.get<SelectionPanel[]>(`${apiBaseUrl}/api/SelectionPanels/Events/Include`)    
    }
    getSelectionPanelById(id: number): Observable<SelectionPanel> {
      return this.http.get<SelectionPanel>(`${apiBaseUrl}/api/SelectionPanels/${id}`)
    } 
    getSelectionPanelWithEventById(id:number): Observable<SelectionPanel[]>
    {
      return this.http.get<SelectionPanel[]>(`${apiBaseUrl}/api/Selectionpanels/Events/Include/${id}`)
    }
    getEventsWithSelectionPanelById(id:number): Observable<SelectionPanel[]>
    {
      return this.http.get<SelectionPanel[]>(`${apiBaseUrl}/api/SelectionPanels/Event/${id}`)
    }
  
    create(data:SelectionPanel):Observable<SelectionPanel>{
      return this.http.post<SelectionPanel>(`${apiBaseUrl}/api/SelectionPanels`, data);
    }
    update(data: SelectionPanel): Observable<any> {
      return this.http.put<SelectionPanel>(`${apiBaseUrl}/api/SelectionPanels/${data.selectionPanelId}`, data);
    }
    delete(id: number): Observable<any> {
      return this.http.delete<any>(`${apiBaseUrl}/api/SelectionPanels/${id}`);
    }
    uploadImage(id: number, f: File): Observable<UploadResponse> {
      const formData = new FormData();
      formData.append('file', f);
      console.log(f);
      return this.http.post<UploadResponse>(`${apiBaseUrl}/api/SelectionPanels/Upload/${id}`, formData);
    }
  }