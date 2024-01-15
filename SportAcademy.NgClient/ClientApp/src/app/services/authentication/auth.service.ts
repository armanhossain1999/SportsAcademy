declare var google:any ;

import { Injectable } from '@angular/core';
import { User } from 'src/app/models/authentication/user-model';
import { LoginService } from './login.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterService } from './register.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user!: User | null;

  constructor(
    private loginService: LoginService,
    private registerService: RegisterService,
    private http: HttpClient,
    private router : Router
  ) {
    this.load();
    this.loginService
      .getEmitter()
      .subscribe((x) => {
        if (x === 'login') {
          this.load();
        }
        if (x === 'logout') {
          this.user = null;
        }
      });
  }

  load() {
    this.user = this.loginService.getCurrentUser();
  }

  // Existing methods...

  logout() {
    this.loginService.logout();
    google.accounts.id.disableAutoSelect();
    this.router.navigate(['login']);
  }

  isLoggedIn() {
    return this.user != null;
  }

  get userName() {
    return this.user?.username ?? '';
  }

  get token() {
    return this.user?.token ?? '';
  }

  get roles() {
    return this.user?.roles;
  }

  roleMatch(allowedRoles: string[]) {
    let isMatch = false;
    for (const r of allowedRoles) {
      let i = this.roles?.indexOf(r);
      if (i != undefined && i >= 0) {
        isMatch = true;
        break;
      }
    }
    return isMatch;
  }

   // New method for registration
   register(user: any): Observable<any> {
    const registerUrl = `${apiBaseUrl}/api/Account/Register`;
    return this.http.post(registerUrl, user);
  }
}
