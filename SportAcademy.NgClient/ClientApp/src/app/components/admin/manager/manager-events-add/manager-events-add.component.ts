import { Component } from '@angular/core';
import { Manager } from 'src/app/models/data/manager';
import { Event } from 'src/app/models/data/event';
import { ManagerService } from 'src/app/services/data/manager.service';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { NotifyService } from 'src/app/services/common/notify.service';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService } from 'src/app/services/data/event.service';
import { ChangeDetectorRef } from '@angular/core';
import { SelectionPanel } from 'src/app/models/data/selectionPanel';
import { SelectionPanelService } from 'src/app/services/data/selectionPanel.service';
import { forkJoin } from 'rxjs';
import { NgZone } from '@angular/core';


@Component({
  selector: 'app-manager-events-add',
  templateUrl: './manager-events-add.component.html',
  styleUrls: ['./manager-events-add.component.scss']
})
export class ManagerEventsAddComponent {

  managers: Manager[] = [];
  manager : Manager = {};
  event : Event [] = [];
  selectionPanels : SelectionPanel [] = []
  eventId:number =0;

  managerForm: FormGroup = new FormGroup({
    managerName: new FormControl('', Validators.required),
    joinDate: new FormControl(undefined, Validators.required),
    email: new FormControl(undefined, Validators.required),
    phone: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    picture: new FormControl(undefined, Validators.required),
    events : new FormArray ([]) 
  });

// Image 
  managerImage: File = null!;
  eventImage: File = null!;


  constructor(
    private managerService: ManagerService,
    private eventService: EventService,
    private selectionPanelService : SelectionPanelService,
    private notifyService: NotifyService,
    private router: Router,
    private activateRouter : ActivatedRoute,
    private cdr: ChangeDetectorRef,
    private ngZone: NgZone
    
  ) {}

  goBackToList() {
    this.router.navigate(['/managers']);
  }
  get f() {
    return this.managerForm.controls;
  }

  get events() {
    return this.managerForm.controls['events'] as FormArray;
  }

 getEventId(id:number){
  this.eventId=id;
 }
 
 addEvent() {
  this.events.push(new FormGroup({
    eventName: new FormControl('', Validators.required),
    startDate: new FormControl(undefined, Validators.required),
    endDate: new FormControl(undefined, Validators.required),
    description: new FormControl('', Validators.required),
    location: new FormControl('', Validators.required),
    picture: new FormControl(undefined, Validators.required),
    selectionPanelId: new FormControl('', Validators.required),
  }));

  // Run change detection in the Angular zone
  this.ngZone.run(() => {});
}

  remove(index: number) {
    this.events.removeAt(index);
  }

  save() {
    if (this.managerForm.invalid) return;
  
    Object.assign(this.manager, this.managerForm.value);
    this.managerService.create(this.manager).subscribe({
      next: r => {
        this.notifyService.message("Data Saved");
  
        // Reset each control in the main form
        Object.keys(this.managerForm.controls).forEach(controlName => {
          const control = this.managerForm.get(controlName);
          if (control) {
            control.reset();
            control.clearValidators();
            control.updateValueAndValidity();
          }
        });
  
        // Reset each form group within the events form array
        for (let i = 0; i < this.events.length; i++) {
          const event = this.events.at(i) as FormGroup;
  
          // Reset each control within the form group
          Object.keys(event.controls).forEach(key => {
            const control = event.get(key);          
              control?.reset();
              control?.clearValidators();
              control?.updateValueAndValidity();         
          });          
        }
  
       this.managerForm.reset();
       this.managerForm.markAllAsTouched();
       this.managerForm.markAsPristine();
      },
      error: err => {
        console.error('Error occurred:', err);
        this.notifyService.message("Failed to save manager");
      }
    });
  }
  

  
  
  uploadManagerImage(id: number) {
    const reader = new FileReader();
    reader.onload = (ev: any) => {
      this.managerService.uploadImage(id, this.managerImage)
        .subscribe({
          next: r => {
            console.log(r);
            this.notifyService.message("Data Saved");
            this.managerForm.reset({});
            this.managers = [];
            this.managerForm.markAsPristine();
            this.managerForm.markAsUntouched();
          },
          error: err => {
            this.notifyService.message("Cannot upload picture");
            console.log(err.message || err);
          }
        });
        
    }
    reader.readAsArrayBuffer(this.managerImage);
  }

  uploadEventImage(id: number) {
    const reader = new FileReader();
    reader.onload = (ev: any) => {
      this.eventService.uploadImage(id, this.eventImage)
        .subscribe({
          next: r => {
            console.log(r);
            this.notifyService.message("Data Saved");
          },
          error: err => {
            this.notifyService.message("Cannot upload picture");
            console.log(err.message || err);
          }
        });
        
    }
    reader.readAsArrayBuffer(this.eventImage);
  }

  //Manager Image 
  onFileSelectManager(event: any) {
    if (event.target.files.length) {
      this.managerImage = event.target.files[0];
      console.log(this.managerImage);
      this.managerForm.patchValue({
        picture: this.managerImage.name
      });
    }
  }

  //Event Image 
  onFileSelectEvent(event: any) {
    if (event.target.files.length) {
      this.eventImage = event.target.files[0];
      console.log(this.event);
      this.events.at(this.eventId).patchValue({
        picture: this.eventImage.name
      });
    }
  }

  ngOnInit(): void {
    this.addEvent(); 
    forkJoin({
      managers: this.managerService.getManagers(),
      selectionPanels: this.selectionPanelService.getSelectionPanels()
    }).subscribe({
      next: (result) => {
        this.managers = result.managers;
        this.selectionPanels = result.selectionPanels;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }
}