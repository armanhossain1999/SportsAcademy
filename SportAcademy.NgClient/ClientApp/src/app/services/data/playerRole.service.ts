import { HttpClient } from "@angular/common/http"
import { Injectable } from "@angular/core"
import { Observable } from "rxjs"
import { UploadResponse } from "src/app/models/common/upload-response"
import { PlayerRole } from "src/app/models/data/playerRole"
import { apiBaseUrl } from "src/app/shared/app-constants"

@Injectable({
    providedIn: 'root'
  })
  export class PlayerRoleService {
    constructor(
      private http:HttpClient
    ) { }
    
    getPlayerRoles(): Observable<PlayerRole[]> {
      return this.http.get<PlayerRole[]>(`${apiBaseUrl}/api/PlayerRoles`)    
    }
  
    getPlayerRolesWithPlayers(): Observable<PlayerRole[]> {
      return this.http.get<PlayerRole[]>(`${apiBaseUrl}/api/PlayerRoles/PlayerRolePlayers/Include`)    
    }
    getPlayerRoleById(id: number): Observable<PlayerRole> 
    {
        return this.http.get<PlayerRole>(`${apiBaseUrl}/api/PlayerRoles/${id}`)
      }
    
  
    create(data:PlayerRole):Observable<PlayerRole>{
      console.log(data)
      return this.http.post<PlayerRole>(`${apiBaseUrl}/api/PlayerRoles`, data);
    }
    update(data: PlayerRole): Observable<any> {
      return this.http.put<PlayerRole>(`${apiBaseUrl}/api/PlayerRoles/${data.playerRoleId}`, data);
    }
    getById(id: number): Observable<PlayerRole> {
      return this.http.get<PlayerRole>(`${apiBaseUrl}/api/PlayerRoles/${id}`)
    }
    delete(id: number): Observable<any> {
      return this.http.delete<any>(`${apiBaseUrl}/api/PlayerRoles/${id}`);
    }
    uploadImage(id: number, f: File): Observable<UploadResponse> {
      const formData = new FormData();
      formData.append('file', f);
      console.log(f);
      return this.http.post<UploadResponse>(`${apiBaseUrl}/api/PlayerRolee/Upload/${id}`, formData);
    }
  }