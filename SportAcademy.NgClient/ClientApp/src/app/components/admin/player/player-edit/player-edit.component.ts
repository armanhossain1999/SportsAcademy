import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Player } from 'src/app/models/data/player';
import { NotifyService } from 'src/app/services/common/notify.service';
import { CategoryService } from 'src/app/services/data/category.service';
import { PlayerService } from 'src/app/services/data/player.service';
import { SportsService } from 'src/app/services/data/sports.service';
import { TeamService } from 'src/app/services/data/team.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';

@Component({
  selector: 'app-player-edit',
  templateUrl: './player-edit.component.html',
  styleUrls: ['./player-edit.component.scss']
})
export class PlayerEditComponent implements OnInit{

  players: Player[] = [];
  player : Player ={};
  // teams: Team []= [];
  // categories: Category[] = [];
  
  playerForm: FormGroup = new FormGroup({
    playerName: new FormControl('', Validators.required),
    // registrationNumber: new FormControl('', Validators.required),
    picture: new FormControl(undefined, Validators.required),
    birthDate: new FormControl(undefined, Validators.required),
    phone: new FormControl(undefined, Validators.required),
    email: new FormControl(undefined, Validators.required),
    address: new FormControl(undefined, Validators.required),
    teamId: new FormControl('', Validators.required),
    categoryId: new FormControl('', Validators.required),
  });

  image: File = null!;
  imagePath:string = apiBaseUrl+'/Pictures'
  
  constructor(
    private teamService: TeamService,
    private playerService : PlayerService,
    private categoryService: CategoryService,
    private sportsService: SportsService,
    private notifyService: NotifyService,
    private router: Router,
    private activateRoutes : ActivatedRoute
  ) { }

  goBackToList() {
    this.router.navigate(['/events']);
  }
  get f() {
    return this.playerForm.controls;
  }

  upload(id:number){
    const reader = new FileReader();
    reader.onload = (ev:any)=>{
      this.playerService.uploadImage(id, this.image)
      .subscribe({
        next:r=>{
          console.log(r);
          
          this.player.picture = r.fileName;
          this.notifyService.message("Player updated", "DISMISS");
          this.image=null!;
        },
        error:err=>{
          console.log(err.message || err);
          this.notifyService.message("Failed to update Player", "DISMISS")
        }
      })
    }
    reader.readAsArrayBuffer(this.image);
  }

    save(){
      if(this.playerForm.invalid) return;
      this.player.playerName = this.f["playerName"].value;
      this.player.birthDate = this.f["birthDate"].value;
      this.player.email = this.f["email"].value;
      this.player.phone = this.f["phone"].value;
      this.player.address = this.f["address"].value
      this.player.picture = this.f["picture"].value

      this.playerService.update(this.player)
      .subscribe({
        next: r=>{
          if(this.image != null){
            this.upload(<number>this.player.playerId);
          }
          else{
            this.notifyService.message("Player updated", "DISMISS")
          }
        },
      error:err=>{
        console.log(err.message || err);
        this.notifyService.message("Failed to update Player", "DISMISS")
      }})
  }

    onFileSelect(event:any){
      if(event.target.files.length){
        this.image =event.target.files[0];
        console.log(this.image);
        this.playerForm.patchValue({
          picture:this.image.name
        });
      }
    }

  ngOnInit(): void {
    let id:number = this.activateRoutes.snapshot.params['id'];
    console.log(id);
    this.playerService.getById(id)
    .subscribe({
      next: r=>{
        this.player=r;
        this.playerForm.patchValue(this.player);
      },
      error:err=>{
        console.log(err.message || err);
        this.notifyService.message("Failed to load Player","DISMISS")
      }
    });
  }
}
