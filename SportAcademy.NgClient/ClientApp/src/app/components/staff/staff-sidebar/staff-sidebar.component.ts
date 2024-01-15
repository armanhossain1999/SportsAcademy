import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/authentication/auth.service';

@Component({
  selector: 'app-staff-sidebar',
  templateUrl: './staff-sidebar.component.html',
  styleUrls: ['./staff-sidebar.component.scss']
})
export class StaffSidebarComponent {
  constructor(public authService: AuthService) {} // Ensure that you inject AuthService in the constructor
}
