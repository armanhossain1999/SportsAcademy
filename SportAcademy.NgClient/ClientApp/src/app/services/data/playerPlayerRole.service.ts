import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, tap, throwError } from 'rxjs';
import { UploadResponse } from 'src/app/models/common/upload-response';
import { PlayerRolePlayer } from 'src/app/models/data/playerRolePlayer';

import { apiBaseUrl } from 'src/app/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class PlayerRolePlayerService {
  constructor(private http: HttpClient) { }

  getPlayerRolePlayers(): Observable<PlayerRolePlayer[]> {
    return this.http.get<PlayerRolePlayer[]>(`${apiBaseUrl}/api/PlayerRolePlayers`);
  }
 
  getPlayersRoleById(id: number): Observable<PlayerRolePlayer> {
    return this.http.get<PlayerRolePlayer>(`${apiBaseUrl}/api/PlayerRolePlayers/${id}`)
  }
  
  create(data: PlayerRolePlayer): Observable<PlayerRolePlayer> {
    return this.http.post<PlayerRolePlayer>(`${apiBaseUrl}/api/PlayerRolePlayers`, data);
  }
  uploadImage(id: number, f: File): Observable<UploadResponse> {
    const formData = new FormData();
    formData.append('file', f);
    console.log(f);
    return this.http.post<UploadResponse>(`${apiBaseUrl}/api/PlayerRolePlayers/Upload/${id}`, formData);
  }

  getById(id: number): Observable<PlayerRolePlayer> {
    return this.http.get<PlayerRolePlayer>(`${apiBaseUrl}/api/PlayerRolePlayers/${id}`)
  }

  update(data: PlayerRolePlayer): Observable<any> {
    return this.http.put<PlayerRolePlayer>(`${apiBaseUrl}/api/PlayerRolePlayers/${data.playerRoleId}`, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/PlayerRolePlayers/${id}`);
  }
}