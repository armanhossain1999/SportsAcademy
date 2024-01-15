import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UploadResponse } from 'src/app/models/common/upload-response';
import { PlayerStatistic } from 'src/app/models/data/playerStatistic';
import { apiBaseUrl } from 'src/app/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class PlayerStatisticsService {
  constructor(private http: HttpClient) { }

  getPlayerStatistics(): Observable<PlayerStatistic[]> {
    return this.http.get<PlayerStatistic[]>(`${apiBaseUrl}/api/PlayerStatistics`);
  }
  getPlayerStatisticsWith():Observable<PlayerStatistic[]> {
    return this.http.get<PlayerStatistic[]>(`${apiBaseUrl}/api/PlayerStatistics/PlayerStatisticsDetails/Include`);
  }

  create(data: PlayerStatistic): Observable<PlayerStatistic> {
    return this.http.post<PlayerStatistic>(`${apiBaseUrl}/api/PlayerStatistics`, data);
  }
  uploadImage(id: number, f: File): Observable<UploadResponse> {
    const formData = new FormData();
    formData.append('file', f);
    console.log(f);
    return this.http.post<UploadResponse>(`${apiBaseUrl}/api/PlayerStatistics/Upload/${id}`, formData);
  }

  getById(id: number): Observable<PlayerStatistic> {
    return this.http.get<PlayerStatistic>(`${apiBaseUrl}/api/PlayerStatistics/${id}`)
  }

  update(data: PlayerStatistic): Observable<any> {
    return this.http.put<PlayerStatistic>(`${apiBaseUrl}/api/PlayerStatistics/${data.playerId}`, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/PlayerStatistics/${id}`);
  }
}