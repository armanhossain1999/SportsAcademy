import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDeleteComponent } from 'src/app/dialogs/confirm-delete/confirm-delete.component';
import { Player } from 'src/app/models/data/player';
import { PlayerStatistic } from 'src/app/models/data/playerStatistic';
import { Sport } from 'src/app/models/data/sport';
import { Team } from 'src/app/models/data/team';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PlayerService } from 'src/app/services/data/player.service';
import { SportsService } from 'src/app/services/data/sports.service';
import { TeamService } from 'src/app/services/data/team.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';

@Component({
  selector: 'app-player-team-list',
  templateUrl: './player-team-list.component.html',
  styleUrls: ['./player-team-list.component.scss']
})
export class PlayerTeamListComponent implements OnInit {
  @Input() numberOfTeams: number = 0; // Receive the numberOfTeams as input
  
  teams: Team[] = [];
  players: Player[] = [];
  sports : Sport [] = [];
  playerStates: PlayerStatistic [] =[];
  searchTerm: string = '';

  teamDataSource: MatTableDataSource<Team> = new MatTableDataSource(this.teams);
  sportsDataSource: MatTableDataSource<Sport> = new MatTableDataSource(this.sports);
  playerDataSource: MatTableDataSource<Player> = new MatTableDataSource(this.players);
  playerStateDataSource: MatTableDataSource<Player> = new MatTableDataSource(this.players);

  columns: string[] = ['expand','teamLogo', 'teamName','captain', 'sportsName', 'actions'];
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  imagePath: string = apiBaseUrl + '/Pictures';
  expandedElement: Team | null = null;

  constructor(
    private teamService: TeamService,
    private sportService : SportsService,
    private playerService : PlayerService,
    private notifyService: NotifyService,
    private matDialog: MatDialog
  ) { }

  getSportsName(sportId: number | undefined): string {
    if (sportId !== undefined) {
      const sport = this.sports.find(s => s.sportId === sportId);
      return sport?.sportsName || 'N/A';
    }
    return 'N/A';
  }

  confirmDelete(Team: Team) {
    this.matDialog.open(ConfirmDeleteComponent, {
      "width": "450px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.teamService.delete(<number>Team.teamId)
            .subscribe({
              next: r => {
                this.teamDataSource.data = this.teamDataSource.data.filter(x => x.teamId != Team.teamId);
              },
              error: err => {
                this.notifyService.message("Failed to delete");
                console.log(err.message || err);
              }
            });
        }
      });
  }

  ngOnInit() {
    this.teamService.getTeamsWithPlayers()
      .subscribe({
        next: teams => {
          this.teams = teams;
          console.log(this.teams);
          this.teamDataSource.data = this.teams;
          this.teamDataSource.sort = this.sort;
          this.teamDataSource.paginator = this.paginator;

          // Define filter predicate here
          this.teamDataSource.filterPredicate = (data, filter) => {
          const searchTermLowerCase = filter.toLowerCase();

          // Use nullish coalescing operator to handle possible undefined values
          return (
            (data.teamName ?? '').toLowerCase().includes(searchTermLowerCase),
            (data.captain ?? '').toLowerCase().includes(searchTermLowerCase)             
          );
        };
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load players data!");
      }
    });  
    this.sportService.getSports().subscribe({
      next: r => {
        this.sports = r;
        this.sportsDataSource.data = this.sports;
        this.sportsDataSource.sort = this.sort;
        this.sportsDataSource.paginator = this.paginator;
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Sports data!");
      }
    }); 
}

  applyFilter() {
    this.teamDataSource.filter = this.searchTerm.trim().toLowerCase();
  }
}
