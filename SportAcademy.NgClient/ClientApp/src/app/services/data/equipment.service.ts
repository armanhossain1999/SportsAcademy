import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core"
import { Observable } from "rxjs"
import { UploadResponse } from "src/app/models/common/upload-response"
import { Equipment } from "src/app/models/data/equipment"
import { apiBaseUrl } from "src/app/shared/app-constants"

@Injectable({
    providedIn: 'root'
  })
  export class EquipmentService {
    constructor(
      private http:HttpClient
    ) { }
    
   
    getEquipments(): Observable<Equipment[]> {
        return this.http.get<Equipment[]>(`${apiBaseUrl}/api/Equipments`)    
      }
    getEquipmentsWithPlayers(): Observable<Equipment[]> {
      return this.http.get<Equipment[]>(`${apiBaseUrl}/api/Equipments/Players/Include`)    
    }
    getEquipmentById(id: number): Observable<Equipment> 
    {
        return this.http.get<Equipment>(`${apiBaseUrl}/api/Equipments/${id}`)
    }   
  
    create(data: Equipment): Observable<Equipment> {
      return this.http.post<Equipment>(`${apiBaseUrl}/api/Equipments`, data);
    }
    
    update(data: Equipment): Observable<Equipment> {
      return this.http.put<Equipment>(`${apiBaseUrl}/api/Equipments/${data.equipmentId}`, data);
    }    
    
    getById(id: number): Observable<Equipment> {
      return this.http.get<Equipment>(`${apiBaseUrl}/api/Equipments/${id}`)
    }
    delete(id: number): Observable<any> {
      return this.http.delete<any>(`${apiBaseUrl}/api/Equipments/${id}`);
    }
  }