import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Manager } from 'src/app/models/data/manager';
import { Event } from 'src/app/models/data/event';
import { NotifyService } from 'src/app/services/common/notify.service';
import { EventService } from 'src/app/services/data/event.service';
import { ManagerService } from 'src/app/services/data/manager.service';
import { SelectionPanelService } from 'src/app/services/data/selectionPanel.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { SelectionPanel } from 'src/app/models/data/selectionPanel';

@Component({
  selector: 'app-event-edit',
  templateUrl: './event-edit.component.html',
  styleUrls: ['./event-edit.component.scss']
})
export class EventEditComponent implements OnInit{

  event: Event = {};
  manager: Manager[] = [];
  selectionPanel: SelectionPanel[] = [];
  
  eventForm: FormGroup = new FormGroup({
    eventName: new FormControl('', Validators.required),
    startDate: new FormControl(undefined, Validators.required),
    endDate: new FormControl(undefined, Validators.required),
    description: new FormControl(undefined, Validators.required),
    location: new FormControl(undefined, Validators.required),
    picture: new FormControl(''),
    selectionPanelId: new FormControl('', Validators.required),
    managerId: new FormControl('', Validators.required),
    
  });
  

  image: File = null!;
  imagePath:string = apiBaseUrl+'/Pictures'
  
  constructor(
    private eventService: EventService,
    private managerService:ManagerService,
    private selectionPanelService : SelectionPanelService,
    private notifyService: NotifyService,
    private router: Router,
    private activateRoute: ActivatedRoute
  ) {}

  goBackToList() {
    this.router.navigate(['/events']);
  }
  get f() {
    return this.eventForm.controls;
  }

  upload(id:number){
    const reader = new FileReader();
    reader.onload = (ev:any)=>{
      this.managerService.uploadImage(id, this.image)
      .subscribe({
        next:r=>{
          console.log(r);
          
          this.event.picture = r.fileName;
          this.notifyService.message("Event updated", "DISMISS");
          this.image=null!;
        },
        error:err=>{
          console.log(err.message || err);
          this.notifyService.message("Failed to update Event", "DISMISS")
        }
      })
    }
    reader.readAsArrayBuffer(this.image);
  }

    save(){
      if(this.eventForm.invalid) return;
      this.event.eventName = this.f["eventName"].value;
      this.event.startDate = this.f["startDate"].value;
      this.event.endDate = this.f["endDate"].value;
      this.event.description = this.f["description"].value;
      this.event.location = this.f["location"].value
      this.event.picture = this.f["picture"].value

      this.eventService.update(this.event)
      .subscribe({
        next: r=>{
          if(this.image != null){
            this.upload(<number>this.event.eventId);
          }
          else{
            this.notifyService.message("Event updated", "DISMISS")
          }
        },
      error:err=>{
        console.log(err.message || err);
        this.notifyService.message("Failed to update Event", "DISMISS")
      }})
  }

    onFileSelect(event:any){
      if(event.target.files.length){
        this.image =event.target.files[0];
        console.log(this.image);
        this.eventForm.patchValue({
          picture:this.image.name
        });
      }
    }

  ngOnInit(): void {
    let id:number = this.activateRoute.snapshot.params['id'];
    console.log(id);
    this.eventService.getById(id)
    .subscribe({
      next: r=>{
        this.event=r;
        this.eventForm.patchValue(this.event);
      },
      error:err=>{
        console.log(err.message || err);
        this.notifyService.message("Failed to load Event","DISMISS")
      }
    });
  }
}
