import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Manager } from 'src/app/models/data/manager';
import { NotifyService } from 'src/app/services/common/notify.service';
import { ManagerService } from 'src/app/services/data/manager.service';
import { Event } from 'src/app/models/data/event';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manager-add',
  templateUrl: './manager-add.component.html',
  styleUrls: ['./manager-add.component.scss']
})
export class ManagerAddComponent implements OnInit {

  manager: Manager = {};
  

  managerForm: FormGroup = new FormGroup({
    managerName: new FormControl('', Validators.required),
    joinDate: new FormControl(undefined, Validators.required),
    email: new FormControl(undefined, Validators.required),
    phone: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    picture: new FormControl(undefined, Validators.required)
   
  });

  image: File = null!;

  constructor(
    private managerService: ManagerService,
    private notifyService: NotifyService,
    private router: Router
  ) {}

  goBackToList() {
    this.router.navigate(['/managers']);
  }
  get f() {
    return this.managerForm.controls;
  }

  save() {
    if (this.managerForm.invalid) return;
  
    const manager: Manager = this.managerForm.value;
  
    this.managerService.create(manager).subscribe({
      next: (r: Manager) => {
        this.notifyService.message("Data Saved");
        this.upload(<number>r.managerId);

        this.managerForm.controls['managerName'].clearValidators();
        this.managerForm.controls['managerName'].updateValueAndValidity();
        this.managerForm.controls['joinDate'].clearValidators();
        this.managerForm.controls['joinDate'].updateValueAndValidity();
        this.managerForm.controls['email'].clearValidators();
        this.managerForm.controls['email'].updateValueAndValidity();
        this.managerForm.controls['phone'].clearValidators();
        this.managerForm.controls['phone'].updateValueAndValidity();
        this.managerForm.controls['address'].clearValidators();
        this.managerForm.controls['address'].updateValueAndValidity();
        this.managerForm.controls['picture'].clearValidators();
        this.managerForm.controls['picture'].updateValueAndValidity();

        this.managerForm.reset(); // Reset the form here
      },
      error: (err) => {
        this.notifyService.message("Failed to save Manager");
      },
    });
  } 

  upload(id: number) {
    const reader = new FileReader();
    reader.onload = (ev: any) => {
      this.managerService.uploadImage(id, this.image)
        .subscribe({
          next: r => {
            console.log(r);
            this.notifyService.message("Data Saved");
            this.managerForm.reset({});
            this.manager = {};
            this.managerForm.markAsPristine();
            this.managerForm.markAsUntouched();
          },
          error: err => {
            this.notifyService.message("Cannot upload picture");
            console.log(err.message || err);
          }
        });
    }
    reader.readAsArrayBuffer(this.image);
  }

  onFileSelect(event: any) {
    if (event.target.files.length) {
      this.image = event.target.files[0];
      console.log(this.image);
      this.managerForm.patchValue({
        picture: this.image.name
      });
    }
  }

  ngOnInit(): void {
    // Initialization logic here
  }
}