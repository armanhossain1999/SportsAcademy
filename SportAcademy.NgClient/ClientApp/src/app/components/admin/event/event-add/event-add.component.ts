import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Event } from 'src/app/models/data/event';
import { Manager } from 'src/app/models/data/manager';
import { NotifyService } from 'src/app/services/common/notify.service';
import { EventService } from 'src/app/services/data/event.service';
import { ManagerService } from 'src/app/services/data/manager.service';
import { SelectionPanelService } from 'src/app/services/data/selectionPanel.service';
import { forkJoin } from 'rxjs';
import { SelectionPanel } from 'src/app/models/data/selectionPanel';

@Component({
  selector: 'app-event-add',
  templateUrl: './event-add.component.html',
  styleUrls: ['./event-add.component.scss']
})
export class EventAddComponent implements OnInit {

  events: Event = {};
  managers: Manager[] = [];
  selectionPanels: SelectionPanel[] = [];

  eventForm: FormGroup = new FormGroup({
    eventName: new FormControl('', Validators.required),
    startDate: new FormControl(undefined, Validators.required),
    endDate: new FormControl(undefined, Validators.required),
    description: new FormControl(undefined, Validators.required),
    location: new FormControl(undefined, Validators.required),
    picture: new FormControl(undefined, Validators.required),
    selectionPanelId: new FormControl('', Validators.required),
    managerId: new FormControl('', Validators.required),

  });


  image: File = null!;

  constructor(
    private eventService: EventService,
    private managerService: ManagerService,
    private selectionPanelService: SelectionPanelService,
    private notifyService: NotifyService,
    private router: Router
  ) { }

  goBackToList() {
    this.router.navigate(['/events']);
  }
  get f() {
    return this.eventForm.controls;
  }

  save() {
    if (this.eventForm.invalid) return;

    const event: Event = this.eventForm.value;

    this.eventService.create(event).subscribe({
      next: (r: Event) => {
        this.notifyService.message("Data Saved");
        this.upload(<number>r.eventId);

        this.eventForm.controls['eventName'].clearValidators();
        this.eventForm.controls['eventName'].updateValueAndValidity();
        this.eventForm.controls['startDate'].clearValidators();
        this.eventForm.controls['startDate'].updateValueAndValidity();
        this.eventForm.controls['endDate'].clearValidators();
        this.eventForm.controls['endDate'].updateValueAndValidity();
        this.eventForm.controls['description'].clearValidators();
        this.eventForm.controls['description'].updateValueAndValidity();
        this.eventForm.controls['location'].clearValidators();
        this.eventForm.controls['location'].updateValueAndValidity();
        this.eventForm.controls['picture'].clearValidators();
        this.eventForm.controls['picture'].updateValueAndValidity();
        this.eventForm.controls['managerId'].clearValidators();
        this.eventForm.controls['managerId'].updateValueAndValidity();
        this.eventForm.controls['selectionPanelId'].clearValidators();
        this.eventForm.controls['selectionPanelId'].updateValueAndValidity();

        this.eventForm.reset(); // Reset the form here
      },
      error: (err) => {
        this.notifyService.message("Failed to save Event");
      },
    });
  }

  upload(id: number) {
    const reader = new FileReader();
    reader.onload = (ev: any) => {
      this.eventService.uploadImage(id, this.image)
        .subscribe({
          next: r => {
            console.log(r);
            this.notifyService.message("Data Saved");
            this.eventForm.reset({});
            this.events = {};
            this.eventForm.markAsPristine();
            this.eventForm.markAsUntouched();
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
      this.eventForm.patchValue({
        picture: this.image.name
      });
    }
  }

  ngOnInit(): void {
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
