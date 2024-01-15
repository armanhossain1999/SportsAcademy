import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, tap, throwError } from 'rxjs';
import { UploadResponse } from 'src/app/models/common/upload-response';
import { Player } from 'src/app/models/data/player';

import { apiBaseUrl } from 'src/app/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  constructor(private http: HttpClient) { }

  getPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>(`${apiBaseUrl}/api/Players`);
  }
  getPlayersWithPlayerStatistics():Observable<Player[]> {
    return this.http.get<Player[]>(`${apiBaseUrl}/api/Players/PlayerStatistics/Include`);
  }
  getPlayerById(id: number): Observable<Player> {
    return this.http.get<Player>(`${apiBaseUrl}/api/Players/${id}`)
  }
  getPlayerWithPlayerSateById(id: number): Observable<Player> {
    return this.http.get<Player>(`${apiBaseUrl}/api/Players/${id}/Include`)
  }

  create(data: Player): Observable<Player> {
    return this.http.post<Player>(`${apiBaseUrl}/api/Players`, data);
  }
  uploadImage(id: number, f: File): Observable<UploadResponse> {
    const formData = new FormData();
    formData.append('file', f);
    console.log(f);
    return this.http.post<UploadResponse>(`${apiBaseUrl}/api/Players/Upload/${id}`, formData);
  }

  getById(id: number): Observable<Player> {
    return this.http.get<Player>(`${apiBaseUrl}/api/Players/${id}`)
  }

  update(data: Player): Observable<any> {
    return this.http.put<Player>(`${apiBaseUrl}/api/Players/${data.playerId}`, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/Players/${id}`);
  }
}