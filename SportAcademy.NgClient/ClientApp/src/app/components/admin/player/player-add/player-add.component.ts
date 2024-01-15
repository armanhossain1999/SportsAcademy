import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { Category } from 'src/app/models/data/category';
import { Player } from 'src/app/models/data/player';
import { Team } from 'src/app/models/data/team';
import { NotifyService } from 'src/app/services/common/notify.service';
import { CategoryService } from 'src/app/services/data/category.service';
import { PlayerService } from 'src/app/services/data/player.service';
import { SportsService } from 'src/app/services/data/sports.service';
import { TeamService } from 'src/app/services/data/team.service';

@Component({
  selector: 'app-player-add',
  templateUrl: './player-add.component.html',
  styleUrls: ['./player-add.component.scss']
})
export class PlayerAddComponent implements OnInit {

  players: Player[] = [];
  player : Player ={};
  teams: Team []= [];
  categories: Category[] = [];
 

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

  constructor(
    private teamService: TeamService,
    private playerService : PlayerService,
    private categoryService: CategoryService,
    private sportsService: SportsService,
    private notifyService: NotifyService,
    private router: Router
  ) { }

  get f() {
    return this.playerForm.controls;
  }

  save() {
    if (this.playerForm.invalid) return;

    const player: Player = this.playerForm.value;

    this.playerService.create(player).subscribe({
      next: (r: Player) => {
        this.notifyService.message("Data Saved");
        this.upload(<number>r.playerId);

        this.playerForm.controls['playerName'].clearValidators();
        this.playerForm.controls['playerName'].updateValueAndValidity();
        // this.playerForm.controls['registrationNumber'].clearValidators();
        // this.playerForm.controls['registrationNumber'].updateValueAndValidity();
        this.playerForm.controls['picture'].clearValidators();
        this.playerForm.controls['picture'].updateValueAndValidity(); 
        this.playerForm.controls['birthDate'].clearValidators();
        this.playerForm.controls['birthDate'].updateValueAndValidity();
        this.playerForm.controls['phone'].clearValidators();
        this.playerForm.controls['phone'].updateValueAndValidity();
        this.playerForm.controls['email'].clearValidators();
        this.playerForm.controls['email'].updateValueAndValidity();
        this.playerForm.controls['address'].clearValidators();
        this.playerForm.controls['address'].updateValueAndValidity();     
        this.playerForm.controls['teamId'].clearValidators();
        this.playerForm.controls['teamId'].updateValueAndValidity();
        this.playerForm.controls['categoryId'].clearValidators();
        this.playerForm.controls['categoryId'].updateValueAndValidity();

        this.playerForm.reset(); // Reset the form here
      },
      error: (err) => {
        this.notifyService.message("Failed to save Player");
      },
    });
  }

  upload(id: number) {
    const reader = new FileReader();
    reader.onload = (ev: any) => {
      this.playerService.uploadImage(id, this.image)
        .subscribe({
          next: r => {
            console.log(r);
            this.notifyService.message("Data Saved");
            this.playerForm.reset({});
            this.player = {};
            this.playerForm.markAsPristine();
            this.playerForm.markAsUntouched();
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
      this.playerForm.patchValue({
        picture: this.image.name
      });
    }
  }

  ngOnInit(): void {
    forkJoin({
      categories: this.categoryService.getCategories(),
      teams: this.teamService.getTeams(),
    }).subscribe({
      next: (result) => {
        this.categories = result.categories;
        this.teams = result.teams;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }
}