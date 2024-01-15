import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDeleteComponent } from 'src/app/dialogs/confirm-delete/confirm-delete.component';
import { Category } from 'src/app/models/data/category';
import { Player } from 'src/app/models/data/player';
import { PlayerRolePlayer } from 'src/app/models/data/playerRolePlayer';
import { NotifyService } from 'src/app/services/common/notify.service';
import { CategoryService } from 'src/app/services/data/category.service';
import { PlayerService } from 'src/app/services/data/player.service';
import { apiBaseUrl } from 'src/app/shared/app-constants';

@Component({
  selector: 'app-player-player-list',
  templateUrl: './player-player-list.component.html',
  styleUrls: ['./player-player-list.component.scss']
})
export class PlayerPlayerListComponent implements OnInit {
  @Input() totalPlayers: number = 0;
  
  players: Player [] = [];
  playerPlayerRoles: PlayerRolePlayer[] = [];
  categories: Category[] = [];
  searchTerm: string = '';

  dataSource: MatTableDataSource<Player> = new MatTableDataSource(this.players);
  categoryDataSource: MatTableDataSource<Category> = new MatTableDataSource(this.categories);
  playerRolePlayerDataSource: MatTableDataSource<PlayerRolePlayer> = new MatTableDataSource(this.playerPlayerRoles);

  columns: string[] = ['expand', 'registrationNumber', 'picture',  'playerName', 'categoryName', 'birthDate', 'phone', 'email', 'address', 'actions'];
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  imagePath: string = apiBaseUrl + '/Pictures';
  expandedElement: Player | null = null;

  playerStatisticCount: number = 0;

  constructor(
    private playerService: PlayerService,
    private categoryService: CategoryService,
    private notifyService: NotifyService,
    private matDialog: MatDialog
  ) { }

  getCategory(categoryId: number | undefined): string {
    if (categoryId !== undefined) {
      const category = this.categories.find(c => c.categoryId === categoryId)
      return category?.categoryName || 'N/A';
    }
    return 'N/A';
  }

  // getPlayerRolePlayers(playerRoleId : number | undefined): string {
  //   if (playerRoleId !== undefined) {
  //     const playerRole = this.playerPlayerRoles.find(pr => pr.playerRoleId === playerRoleId)
  //     return playerRole?.roleName || 'N/A';
  //   }
  //   return 'N/A';
  // }


  receivesDataFromChild(playerStatisticCount: number) {
    this.playerService.getPlayersWithPlayerStatistics()
      .subscribe({
        next: r => {
          this.players = r;
          console.log(this.players);
          this.dataSource.data = this.players;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        },
        error: err => {
          this.notifyService.message("Failed to delete");
          console.log(err.message || err);
        }
      });
  }



  ngOnInit() {
    this.playerService.getPlayersWithPlayerStatistics()
      .subscribe({
        next: players => {
          this.players = players;
          console.log(this.players);
          this.dataSource.data = this.players;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;

          // Define filter predicate here
          this.dataSource.filterPredicate = (data, filter) => {
            const searchTermLowerCase = filter.toLowerCase();

            // Use nullish coalescing operator to handle possible undefined values
            return (
              (data.playerName ?? '').toLowerCase().includes(searchTermLowerCase) ||
              (data.email ?? '').toLowerCase().includes(searchTermLowerCase) ||
              (data.address ?? '').toLowerCase().includes(searchTermLowerCase) ||
              (data.phone ?? '').toLowerCase().includes(searchTermLowerCase)


            );
          };
        },
        error: err => {
          console.log(err.message || err);
          this.notifyService.message("Failed to load players data!");
        }
      });
    this.categoryService.getCategories().subscribe({
      next: r => {
        this.categories = r;
        this.categoryDataSource.data = this.players;
        this.categoryDataSource.sort = this.sort;
        this.categoryDataSource.paginator = this.paginator;
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Category data!");
      }
    });
  }

  applyFilter() {
    this.dataSource.filter = this.searchTerm.trim().toLowerCase();
  }


  confirmDelete(players: Player) {
    this.matDialog.open(ConfirmDeleteComponent, {
      "width": "450px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.playerService.delete(<number>players.playerId)
            .subscribe({
              next: r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.playerId != players.playerId);
              },
              error: err => {
                this.notifyService.message("Failed to delete");
                console.log(err.message || err);
              }
            });
        }
      });
  }
  handleDetailDeleted(event: { playerId: number; detailId: number }): void {
    // Perform any actions here based on the deleted detail
    console.log(`Detail deleted for Manager ID: ${event.playerId}, Detail ID: ${event.detailId}`);
  }
}