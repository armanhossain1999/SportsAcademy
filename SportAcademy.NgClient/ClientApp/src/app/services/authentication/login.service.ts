import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { LoginModel } from 'src/app/models/authentication/login-model';
import { User } from 'src/app/models/authentication/user-model';
import { NotifyService } from '../common/notify.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  currentUserSubject: BehaviorSubject<User|null>=null!;
  @Output() loginEvent: EventEmitter<string> = new EventEmitter<string>();
  constructor(
    private http:HttpClient
  ) { 
    let userdata = sessionStorage.getItem("user-data") as string;
    if(userdata){
      this.currentUserSubject = new BehaviorSubject<User|null>(JSON.parse(userdata));
    }
    else
      this.currentUserSubject = new BehaviorSubject<User|null>(null);

  }
  getCurrentUser():User|null{
    return this.currentUserSubject.value;
  }
  login(data:LoginModel){
     this.http.post<any>(`http://localhost:5261/api/Account/Login`, data)
     .subscribe({
      next: r=>{
        console.log(r);
        let user = this.save(r);
        console.log(user);
        this.currentUserSubject.next(user);
        console.log(this.currentUserSubject.value)
        this.loginEvent.emit('login')
      },
      error: err=>{}
     })
  }

    logout() {
      sessionStorage.removeItem("user-data");
      this.currentUserSubject.next(null);
      this.loginEvent.emit('logout');
    }
  
  save(data:any):User {
    console.log(data)
    var user:User = {};
    user.token = data.token;
    console.log(window.atob(data.token.split('.')[1]));
    const payload = JSON.parse(window.atob(data.token.split('.')[1]));
    //console.log(payload);
    user.username = payload.username;
    user.roles = payload.roles.split(",")
    sessionStorage.setItem("user-data", JSON.stringify(user));
    //console.log(user);
    return user;
  }
  getEmitter() {
    return this.loginEvent;
  }
}