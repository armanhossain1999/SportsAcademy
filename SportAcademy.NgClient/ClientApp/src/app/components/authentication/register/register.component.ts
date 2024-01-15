import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms'; // Import NgForm
import { AuthService } from 'src/app/services/authentication/auth.service';
import { Router } from '@angular/router';
import { NotifyService } from 'src/app/services/common/notify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  data: any = {};
  @ViewChild('registerForm') registerForm!: NgForm; // Use non-null assertion operator

  constructor(
    private authService: AuthService,
    private notifyService: NotifyService,
    private router: Router
  ) {}
 
  register(): void {
    this.authService.register(this.data)
      .subscribe(
        (response) => {
          console.log('Registration successful', response);
          this.notifyService.message('User created successfully');
          this.registerForm.resetForm(); 
        },
        (error) => {
          console.error('Registration failed', error);
          this.notifyService.message('User registration failed', 'Close');
        }
      );
  }
}
