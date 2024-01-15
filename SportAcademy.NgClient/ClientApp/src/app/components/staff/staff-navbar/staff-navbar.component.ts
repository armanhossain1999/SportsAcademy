import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit, ViewChild, inject } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { Observable, map, shareReplay } from 'rxjs';
import { AuthService } from 'src/app/services/authentication/auth.service';

@Component({
  selector: 'app-staff-navbar',
  templateUrl: './staff-navbar.component.html',
  styleUrls: ['./staff-navbar.component.scss']
})
export class StaffNavbarComponent implements OnInit {
  @ViewChild(MatSidenav)
  staffSivebar! : MatSidenav;

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
  toggleStaffSidebar() {
    this.staffSivebar.toggle();
  }
}
