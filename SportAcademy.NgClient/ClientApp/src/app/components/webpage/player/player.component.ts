import { Component, OnInit } from '@angular/core';
import { Player } from 'src/app/models/data/player';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PlayerService } from 'src/app/services/data/player.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.scss']
})
export class PlayerComponent implements OnInit {

  players: Player[] = [];

  constructor(
    private playerService: PlayerService,
    private notifyService: NotifyService
  ) { }
  
  imagePath: string = apiBaseUrl + '/Pictures';

  ngOnInit(): void {
    this.getPlayers();
  }

  getPlayers(): void {
    this.playerService.getPlayers().subscribe(
      (players: Player[]) => {
        this.players = players;
      },
      (error) => {
        console.error('Error fetching players:', error);
        this.notifyService.message("Failed to load Players data!");
      }
    );
  }
}
