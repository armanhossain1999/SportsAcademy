import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDeleteComponent } from 'src/app/dialogs/confirm-delete/confirm-delete.component';
import { Player } from 'src/app/models/data/player';
import { PlayerStatistic } from 'src/app/models/data/playerStatistic';
import { Team } from 'src/app/models/data/team';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PlayerService } from 'src/app/services/data/player.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { PlayerAddComponent } from '../../player/player-add/player-add.component';
import { PlayerStatisticsService } from 'src/app/services/data/playerStatistics.service';

@Component({
  selector: 'app-team-player',
  templateUrl: './team-player.component.html',
  styleUrls: ['./team-player.component.scss']
})
export class TeamPlayerComponent implements OnInit {

  @Input() players: Player[] = [];

  @Input() playerStatistics : PlayerStatistic[]= [];

  teams: Team[] = [];
  imagePath: string = apiBaseUrl + '/Pictures';
  expandedElement: PlayerStatistic | null = null;

  dataSource: MatTableDataSource<Player> = new MatTableDataSource(this.players);
  playerStateDataSource: MatTableDataSource<PlayerStatistic> = new MatTableDataSource(this.playerStatistics);

  columns: string[] = ['picture','playerName','registrationNumber', 'birthDate', 'phone', 'email', 'address', 'actions'];

  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  constructor(
    private playerService: PlayerService,
    private playerStateService : PlayerStatisticsService,
    private notifyService: NotifyService,
    private matDialog: MatDialog,
  ) { }

  @Input() teamName = '';
  @Input() playerName = '';

  get player(): Player[] {
    return this.players;
  }

  @Input() set player(value: Player[]) {
    this.players = value;
    console.log(value)
    this.dataSource.data = this.players;
  }
  

  get playerStatistic(): PlayerStatistic[] {
    return this.playerStatistics;
  }

  @Input() set playerStatistic(value: PlayerStatistic[]) {
    this.playerStatistics = value;
    console.log(value);
    this.dataSource.data = this.playerStatistics;
  }  
 
  @Output() childOutputProperty:EventEmitter<number> = new EventEmitter();



 

  confirmDelete(player: Player) {
    this.matDialog.open(ConfirmDeleteComponent, {
      width: '450px'
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.playerService.delete(<number>player.playerId)
            .subscribe({
              next: r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.playerId != player.playerId);
                this.notifyService.message('Event deleted successfully.');
                this.childOutputProperty.emit(<number>this.players.length)
              },
              error: err => {
                this.notifyService.message('Failed to delete event.');
                console.log(err.message || err);
              }
            });
        }
      });
  }

  ngOnInit() {
    // this.playerStateService.getPlayerStatistics()
    // .subscribe({
    //   next: r => {
    //     this.playerStatistics = r;
    //     this.playerStateDataSource.data = this.playerStatistics;
    //   },
    //   error: err => {
    //     console.log(err.message || err);
    //     this.notifyService.message("Failed to load playerStatistics data!");
    //   }
    // });  
  }
}