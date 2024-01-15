import { Component, OnInit, ViewChild, inject } from '@angular/core';
import { BreakpointObserver, Breakpoints} from '@angular/cdk/layout'
import { MatSidenav } from '@angular/material/sidenav';
import { AuthService } from 'src/app/services/authentication/auth.service';
import { Router } from '@angular/router';
import { Observable, map, shareReplay } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  @ViewChild(MatSidenav)
  sidenav! : MatSidenav;

  private breakpointObserver = inject(BreakpointObserver);
  constructor(
    private authSevice: AuthService,
    private router:Router
  ){}

  ngOnInit(): void {
    
  }   
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
  .pipe(
    map(result => result.matches),
    shareReplay()
  );
  get username (){
    return this.authSevice.userName;
  }
  get isLoggedIn()
  {
    return this.authSevice.isLoggedIn();
  }
  logout(){
    this.authSevice.logout();
    this.router.navigateByUrl('/login')
  }
  toggleSidebar() {
    this.sidenav.toggle();
  }
}
  
  
