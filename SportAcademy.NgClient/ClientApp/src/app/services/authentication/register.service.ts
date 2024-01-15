import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { apiBaseUrl } from 'src/app/shared/app-constants';


@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  private apiUrl = apiBaseUrl; 

  constructor(private http: HttpClient) {}

  register(user: any): Observable<any> {
    const registerUrl = `${this.apiUrl}/api/Account/Register`; 
    return this.http.post(registerUrl, user);
  }
}
