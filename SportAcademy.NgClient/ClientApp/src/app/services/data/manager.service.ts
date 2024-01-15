import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UploadResponse } from 'src/app/models/common/upload-response';
import { Manager } from 'src/app/models/data/manager';

import { apiBaseUrl } from 'src/app/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {
  constructor(private http: HttpClient) { }

  getManagers(): Observable<Manager[]> {
    return this.http.get<Manager[]>(`${apiBaseUrl}/api/Managers`);
  }
  getManagersWithEvents():Observable<Manager[]> {
    return this.http.get<Manager[]>(`${apiBaseUrl}/api/Managers/Events/Include`);
  }

  create(data: Manager): Observable<Manager> {
    return this.http.post<Manager>(`${apiBaseUrl}/api/Managers`, data);
  }
  uploadImage(id: number, f: File): Observable<UploadResponse> {
    const formData = new FormData();
    formData.append('file', f);
    console.log(f);
    return this.http.post<UploadResponse>(`${apiBaseUrl}/api/Managers/Upload/${id}`, formData);
  }

  getManagerById(id: number): Observable<Manager> {
    return this.http.get<Manager>(`${apiBaseUrl}/api/Managers/${id}`)
  }

  update(data: Manager): Observable<any> {
    return this.http.put<Manager>(`${apiBaseUrl}/api/Managers/${data.managerId}`, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/Managers/${id}`);
  }
}