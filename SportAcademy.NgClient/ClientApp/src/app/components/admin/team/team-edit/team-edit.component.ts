import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Sport } from 'src/app/models/data/sport';
import { Team } from 'src/app/models/data/team';
import { NotifyService } from 'src/app/services/common/notify.service';
import { SportsService } from 'src/app/services/data/sports.service';
import { TeamService } from 'src/app/services/data/team.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';

@Component({
  selector: 'app-team-edit',
  templateUrl: './team-edit.component.html',
  styleUrls: ['./team-edit.component.scss']
})
export class TeamEditComponent implements OnInit{

  team: Team = {};
  sports: Sport[] = [];
  
  teamForm: FormGroup = new FormGroup({
    teamName: new FormControl('', Validators.required),
    captain: new FormControl(undefined, Validators.required),
    teamLogo: new FormControl(undefined),
    sportId: new FormControl('', Validators.required),
  });

  image: File = null!;
  imagePath:string = apiBaseUrl+'/Pictures'
  
  constructor(
    private teamService: TeamService,
    private sportsService: SportsService,
    private notifyService: NotifyService,
    private router: Router,
    private activateRoute: ActivatedRoute

  ) { }

  goBackToList() {
    this.router.navigate(['/teams']);
  }
  get f() {
    return this.teamForm.controls;
  }

  upload(id:number){
    const reader = new FileReader();
    reader.onload = (ev:any)=>{
      this.teamService.uploadImage(id, this.image)
      .subscribe({
        next:r=>{
          console.log(r);
          
          this.team.teamLogo = r.fileName;
          this.notifyService.message("Team updated", "DISMISS");
          this.image=null!;
        },
        error:err=>{
          console.log(err.message || err);
          this.notifyService.message("Failed to update Team", "DISMISS")
        }
      })
    }
    reader.readAsArrayBuffer(this.image);
  }

    save(){
      if(this.teamForm.invalid) return;
      this.team.teamName = this.f["teamName"].value;
      this.team.captain = this.f["captain"].value;
      this.team.teamLogo = this.f["teamLogo"].value

      this.teamService.update(this.team)
      .subscribe({
        next: r=>{
          if(this.image != null){
            this.upload(<number>this.team.teamId);
          }
          else{
            this.notifyService.message("team updated", "DISMISS")
          }
        },
      error:err=>{
        console.log(err.message || err);
        this.notifyService.message("Failed to update team", "DISMISS")
      }})
  }

  onFileSelect(event: any) {
    if (event.target.files.length) {
      this.image = event.target.files[0];
      console.log(this.image);
      this.teamForm.patchValue({
        teamLogo: this.image.name
      });
    }
  }

  ngOnInit(): void {
    let id: number = this.activateRoute.snapshot.params['id'];
    console.log(id);
    this.teamService.getById(id)
      .subscribe({
        next: r => {
          this.team = r;
          // Patch values to the form
          this.teamForm.patchValue({
            teamName: this.team.teamName,
            captain: this.team.captain,
            teamLogo: this.team.teamLogo,
            sportId: this.team.sportId,  // Set the sportId value
          });
        },
        error: err => {
          console.log(err.message || err);
          this.notifyService.message("Failed to load team", "DISMISS");
        }
      });
  
    // Fetch sports data
    this.sportsService.getSports()
      .subscribe({
        next: sports => {
          this.sports = sports;
        },
        error: err => {
          console.log(err.message || err);
          this.notifyService.message("Failed to load sports", "DISMISS");
        }
      });
  }
}  