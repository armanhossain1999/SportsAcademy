import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { Player } from 'src/app/models/data/player';
import { Sport } from 'src/app/models/data/sport';
import { Team } from 'src/app/models/data/team';
import { NotifyService } from 'src/app/services/common/notify.service';
import { SportsService } from 'src/app/services/data/sports.service';
import { TeamService } from 'src/app/services/data/team.service';

@Component({
  selector: 'app-team-add',
  templateUrl: './team-add.component.html',
  styleUrls: ['./team-add.component.scss']
})
export class TeamAddComponent implements OnInit {

  team: Team = {};
  sports: Sport[] = [];
  players: Player[] = [];

  teamForm: FormGroup = new FormGroup({
    teamName: new FormControl('', Validators.required),
    captain: new FormControl(undefined, Validators.required),
    teamLogo: new FormControl(undefined, Validators.required),
    sportId: new FormControl('', Validators.required),
  });

  image: File = null!;

  constructor(
    private teamService: TeamService,
    private sportsService: SportsService,
    private notifyService: NotifyService,
    private router: Router
  ) { }

  goBackToList() {
    this.router.navigate(['/team']);
  }
  get f() {
    return this.teamForm.controls;
  }

  save() {
    if (this.teamForm.invalid) return;

    const team: Team = this.teamForm.value;

    this.teamService.create(team).subscribe({
      next: (r: Team) => {
        this.notifyService.message("Data Saved");
        this.upload(<number>r.teamId);

        this.teamForm.controls['teamName'].clearValidators();
        this.teamForm.controls['teamName'].updateValueAndValidity();
        this.teamForm.controls['captain'].clearValidators();
        this.teamForm.controls['captain'].updateValueAndValidity();
        this.teamForm.controls['teamLogo'].clearValidators();
        this.teamForm.controls['teamLogo'].updateValueAndValidity();      
        this.teamForm.controls['sportId'].clearValidators();
        this.teamForm.controls['sportId'].updateValueAndValidity();

        this.teamForm.reset(); // Reset the form here
      },
      error: (err) => {
        this.notifyService.message("Failed to save Team");
      },
    });
  }

  upload(id: number) {
    const reader = new FileReader();
    reader.onload = (ev: any) => {
      this.teamService.uploadImage(id, this.image)
        .subscribe({
          next: r => {
            console.log(r);
            this.notifyService.message("Data Saved");
            this.teamForm.reset({});
            this.team = {};
            this.teamForm.markAsPristine();
            this.teamForm.markAsUntouched();
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
      this.teamForm.patchValue({
        teamLogo: this.image.name
      });
    }
  }

  ngOnInit(): void {
    forkJoin({
      sports: this.sportsService.getSports(),
    }).subscribe({
      next: (result) => {
        this.sports = result.sports;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }
}
