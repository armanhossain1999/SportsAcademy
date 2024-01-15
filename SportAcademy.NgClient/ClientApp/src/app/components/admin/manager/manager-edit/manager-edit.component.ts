import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Manager } from 'src/app/models/data/manager';
import { NotifyService } from 'src/app/services/common/notify.service';
import { ManagerService } from 'src/app/services/data/manager.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-manager-edit',
  templateUrl: './manager-edit.component.html',
  styleUrls: ['./manager-edit.component.scss']
})
export class ManagerEditComponent implements OnInit{
  
  manager: Manager = {};
  
  managerForm: FormGroup = new FormGroup({
    managerName: new FormControl('', Validators.required),
    joinDate: new FormControl(undefined, Validators.required),
    email: new FormControl(undefined, Validators.required),
    phone: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    picture: new FormControl("", Validators.required),
   
  });

  constructor(
    private managerService: ManagerService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute
  ) {}
  
  image:File = null!;
  imagePath:string = apiBaseUrl+'/Pictures'
  
    //Properties
    get f(){
      return this.managerForm.controls;
    }
  
    upload(id:number){
      const reader = new FileReader();
      reader.onload = (ev:any)=>{
        this.managerService.uploadImage(id, this.image)
        .subscribe({
          next:r=>{
            console.log(r);
            
            this.manager.picture = r.fileName;
            this.notifyService.message("Item updated", "DISMISS");
            this.image=null!;
          },
          error:err=>{
            console.log(err.message || err);
            this.notifyService.message("Failed to update item", "DISMISS")
          }
        })
      }
      reader.readAsArrayBuffer(this.image);
    }

    save(){
      if(this.managerForm.invalid) return;
      this.manager.managerName = this.f["managerName"].value;
      this.manager.joinDate = this.f["joinDate"].value;
      this.manager.email = this.f["email"].value;
      this.manager.phone = this.f["phone"].value;
      this.manager.address = this.f["address"].value

      this.managerService.update(this.manager)
      .subscribe({
        next: r=>{
          if(this.image != null){
            this.upload(<number>this.manager.managerId);
          }
          else{
            this.notifyService.message("Manager updated", "DISMISS")
          }
        },
      error:err=>{
        console.log(err.message || err);
        this.notifyService.message("Failed to update Manager", "DISMISS")
      }})
  }

    onFileSelect(event:any){
      if(event.target.files.length){
        this.image =event.target.files[0];
        console.log(this.image);
        this.managerForm.patchValue({
          picture:this.image.name
        });
      }
    }

  ngOnInit(): void {
    let id:number = this.activatedRoute.snapshot.params['id'];
    console.log(id);
    this.managerService.getManagerById(id)
    .subscribe({
      next: r=>{
        this.manager=r;
        this.managerForm.patchValue(this.manager);
      },
      error:err=>{
        console.log(err.message || err);
        this.notifyService.message("Failed to load Manager","DISMISS")
      }
    });
  }
}
