import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDeleteComponent } from 'src/app/dialogs/confirm-delete/confirm-delete.component';
import { Player } from 'src/app/models/data/player';
import { PlayerStatistic } from 'src/app/models/data/playerStatistic';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PlayerStatisticsService } from 'src/app/services/data/playerStatistics.service';

@Component({
  selector: 'app-player-player-statistics',
  templateUrl: './player-player-statistics.component.html',
  styleUrls: ['./player-player-statistics.component.scss']
})
export class PlayerPlayerStatisticsComponent implements OnInit {

  @Input() playerStatistics: PlayerStatistic[] = [];
  players: Player[] = [];

  @Output() playerStatisticsChange: EventEmitter<PlayerStatistic[]> = new EventEmitter<PlayerStatistic[]>();


  battingColumns: string[] = ['matches', 'innings', 'runs', 'balls', 'average', 'fifty', 'hundred', 'sixs', 'fours', 'highest', 'ducks', 'actions'];
  bowlingColumns: string[] = ['matches', 'innings', 'wicket', 'maidens', 'economy', 'actions'];

  dataSource: MatTableDataSource<PlayerStatistic> = new MatTableDataSource(this.playerStatistics);
  
  //columns: string[] = ['matches','innings', 'runs', 'balls', 'average', 'fifty','hundred','sixs','fours','highest','ducks','wicket','maidens','economy','actions'];

  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  @Output() detailDeleted: EventEmitter<{ playerId: number, detailId: number }> = new EventEmitter<{ playerId: number, detailId: number }>();

  constructor(
    private playerStatisticsService: PlayerStatisticsService,
    private notifyService: NotifyService,
    private matDialog: MatDialog,
  ) { }

  @Input() playerName = '';

  @Input() set playerStatistic(value: PlayerStatistic[]) {
    this.playerStatistics = value;
    console.log(value);
    this.dataSource.data = this.playerStatistics;
  }  

  @Output() childOutputProperty:EventEmitter<number> = new EventEmitter();

  get playerStatistic(): PlayerStatistic[] {
    return this.playerStatistics;
  }
  confirmDelete(playerStatistic: PlayerStatistic) {
    this.matDialog.open(ConfirmDeleteComponent, {
      width: '450px'
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.playerStatisticsService.delete(<number>playerStatistic.playerStatisticId)
            .subscribe({
              next: r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.playerStatisticId != playerStatistic.playerStatisticId);
                this.notifyService.message('PlayerStatistic deleted successfully.');
                this.childOutputProperty.emit(<number>this.playerStatistic.length)
              },
              error: err => {
                this.notifyService.message('Failed to delete PlayerStatistic.');
                console.log(err.message || err);
              }
            });
        }
      });
  }

  ngOnInit(): void {
    // Initialization logic here
  }
}
