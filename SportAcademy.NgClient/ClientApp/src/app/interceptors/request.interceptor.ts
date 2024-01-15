import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/authentication/auth.service';

@Injectable()
export class RequestInterceptor implements HttpInterceptor {
  constructor(
    private authService:AuthService
  ) {}
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
     if(this.authService.isLoggedIn()){
      let token = this.authService.token;
      request = request.clone({
        setHeaders:{
          Authorization: `Bearer ${token}`
        }
      })
      console.log(request.headers.get('Authorization'))
    }
    return next.handle(request);
  }
}
