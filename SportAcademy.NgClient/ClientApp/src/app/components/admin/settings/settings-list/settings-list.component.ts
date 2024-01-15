import { AfterViewInit, Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDeleteComponent } from 'src/app/dialogs/confirm-delete/confirm-delete.component';
import { Category } from 'src/app/models/data/category';
import { CricketFormat } from 'src/app/models/data/cricketFormat';
import { Sport } from 'src/app/models/data/sport';
import { NotifyService } from 'src/app/services/common/notify.service';
import { CategoryService } from 'src/app/services/data/category.service';
import { CricketFormatsService } from 'src/app/services/data/cricketFormat.service';
import { SportsService } from 'src/app/services/data/sports.service';
import { ChangeDetectorRef } from '@angular/core';
import { delay } from 'rxjs';
import { TrainingSession } from 'src/app/models/data/trainingSession';
import { TrainingSessionService } from 'src/app/services/data/trainingSession.service';
import { Coach } from 'src/app/models/data/coach';
import { CoachService } from 'src/app/services/data/coach.service';
import { PlayerRole } from 'src/app/models/data/playerRole';
import { PlayerRoleService } from 'src/app/services/data/playerRole.service';
import { Equipment } from 'src/app/models/data/equipment';
import { EquipmentService } from 'src/app/services/data/equipment.service';
import { CoachSpecializaton } from 'src/app/models/data/coachSpecialization';
import { CoachSpecializatonService } from 'src/app/services/data/coachSpecialization.service';


@Component({
  selector: 'app-settings-list',
  templateUrl: './settings-list.component.html',
  styleUrls: ['./settings-list.component.scss']
})
export class SettingsListComponent implements OnInit, AfterViewInit {

  //Sports
  sports: Sport[] = [];
  dataSource: MatTableDataSource<Sport> = new MatTableDataSource(this.sports);
  columns: string[] = ['sportId', 'sportsName', 'actions']

  sport: Sport = {};
  sportsForm: FormGroup = new FormGroup({
    sportsName: new FormControl(undefined, Validators.required),
  });

  //Cricket Format
  cricketFormats: CricketFormat[] = [];
  cricketFormatDataSource: MatTableDataSource<CricketFormat> = new MatTableDataSource(this.cricketFormats);
  cricketFormatsColumns: string[] = ['cricketFormatId', 'formatName', 'actions']

  cricketFormat: CricketFormat = {};
  cricketFormatForm: FormGroup = new FormGroup({
    formatName: new FormControl(undefined, Validators.required),
    sportId: new FormControl(undefined, Validators.required),
  });

  //Category
  categories: Category[] = [];
  categoryDataSource: MatTableDataSource<Category> = new MatTableDataSource(this.categories);
  categoriescolumns: string[] = ['categoryId', 'categoryName', 'actions']

  category: Sport = {};
  categoriesForm: FormGroup = new FormGroup({
    categoryName: new FormControl(undefined, Validators.required),
  });
  //Training Session
  trainingSessions: TrainingSession[] = [];
  trainingSessionDataSource: MatTableDataSource<TrainingSession> = new MatTableDataSource(this.trainingSessions);
  trainingSessionsColumns: string[] = ['title', 'coachName', 'sessionTime', 'description', 'actions']

  trainingSession: TrainingSession = {};
  trainingSessionForm: FormGroup = new FormGroup({
    title: new FormControl('', Validators.required),
    sessionTime: new FormControl(undefined, Validators.required),
    description: new FormControl('', Validators.required),
    coachId: new FormControl(undefined, Validators.required),
  });

  //PlayerRole
  playerRoles: PlayerRole[] = [];
  playerRolesDataSource: MatTableDataSource<PlayerRole> = new MatTableDataSource(this.playerRoles);
  playerRolesColumns: string[] = ['playerRoleId', 'roleName', 'actions']

  playerRole: PlayerRole = {};
  playerRoleForm: FormGroup = new FormGroup({
    roleName: new FormControl('', Validators.required),
  });

  //Equipment
  equipments: Equipment[] = [];
  equipmentsDataSource: MatTableDataSource<Equipment> = new MatTableDataSource(this.equipments);
  equipmentsColumns: string[] = ['equipmentId', 'equipmentName', 'actions']

  equipment: Equipment = {};
  equipmentsForm: FormGroup = new FormGroup({
    equipmentName: new FormControl(undefined, Validators.required),
    trainingSessionId: new FormControl(undefined, Validators.required),

  });

  //Equipment
  coachSpecializatons: CoachSpecializaton[] = [];
  coachSpecializatonDataSource: MatTableDataSource<CoachSpecializaton> = new MatTableDataSource(this.coachSpecializatons);
  coachSpecializatonColumns: string[] = ['coachSpecializationId', 'specializedIn', 'actions']

  coachSpecializaton: CoachSpecializaton = {};
  coachSpecializatonsForm: FormGroup = new FormGroup({
    specializedIn: new FormControl(undefined, Validators.required),
    coachId: new FormControl(undefined, Validators.required),

  });

  @ViewChild(MatSort) sportsSort!: MatSort;
  @ViewChild('sportsPaginator') sportsPaginator!: MatPaginator;

  @ViewChild(MatSort) cricketFormatsSort!: MatSort;
  @ViewChild('cricketFormatsPaginator') cricketFormatsPaginator!: MatPaginator;

  @ViewChild(MatSort) categoriesSort!: MatSort;
  @ViewChild('categoriesPaginator') categoriesPaginator!: MatPaginator;

  @ViewChild(MatSort) trainingSessionSort!: MatSort;
  @ViewChild('trainingSessionPaginator') trainingSessionPaginator!: MatPaginator;

  @ViewChild(MatSort) playerRolesort!: MatSort;
  @ViewChild('playerRolePaginator') playerRolePaginator!: MatPaginator;

  @ViewChild(MatSort) equipmentSort!: MatSort;
  @ViewChild('equipmentPaginator') equipmentPaginator!: MatPaginator;

  @ViewChild(MatSort) coachSpecializatonsSort!: MatSort;
  @ViewChild('coachSpecializatonsPaginator') coachSpecializatonsPaginator!: MatPaginator;


  constructor(
    private sportsService: SportsService,
    private cricketFormateService: CricketFormatsService,
    private categoryService: CategoryService,
    private coachService: CoachService,
    private trainingSessionService: TrainingSessionService,
    private playerRoleService: PlayerRoleService,
    private coachSpecializatonService: CoachSpecializatonService,
    private equipmentService: EquipmentService,
    private notifyService: NotifyService,
    private matDialog: MatDialog,
    private cdr: ChangeDetectorRef
  ) { }

  get f() {
    return this.cricketFormatForm.controls;
  }
  get tsf() {
    return this.trainingSessionForm.controls;
  }
  get sportsControls() {
    return this.sportsForm.controls;
  }
  get cricketFormateControls() {
    return this.cricketFormatForm.controls;
  }
  get categoriesControls() {
    return this.categoriesForm.controls;
  }
  get trainingSessionControls() {
    return this.trainingSessionForm.controls;
  }
  get playerRolesControls() {
    return this.playerRoleForm.controls;
  }
  get equipmentsControls() {
    return this.equipmentsForm.controls;
  }
  get coachSpecializatonControls() {
    return this.coachSpecializatonsForm.controls;
  }

  //To get coach name in TrainingSession table
  coaches: Coach [] = [];
  coachDataSource: MatTableDataSource<Coach> = new MatTableDataSource(this.coaches);

  getCoachName(coachId: number | undefined): string {
    if (coachId !== undefined) {
      const coach = this.coaches.find(c => c.coachId === coachId);
      return coach?.coachName || 'N/A';
    }
    return 'N/A';
  }

  //reset the form
  resetForms() {
    this.sportsForm.reset();
    this.cricketFormatForm.reset();
    this.categoriesForm.reset();
    this.trainingSessionForm.reset();
    this.playerRoleForm.reset();
    this.equipmentsForm.reset();
    this.coachSpecializatonsForm.reset();
  }

  // Create and Edit Sports

  isEditing: boolean = false;
  editingItemId: number | undefined = undefined;

  editSports(element: any) {
    this.isEditing = true;
    this.editingItemId = element.sportId ?? undefined;
    this.sportsForm.patchValue({
      sportsName: element.sportsName,
    });
  }

  saveSports() {
    if (this.sportsForm.invalid) return;

    const sport: Sport = this.sportsForm.value;

    if (this.isEditing) {
      // Include the sportId when updating
      sport.sportId = this.editingItemId;

      this.sportsService.update(sport)
        .subscribe({
          next: (updatedSport: Sport) => {
            this.loadSports();
            const index = this.sports.findIndex(s => s.sportId === updatedSport.sportId);
            this.isEditing = false;
            this.editingItemId = undefined;
            this.sports[index] = updatedSport;
            this.notifyService.message("Data Saved");
            this.cdr.detectChanges();


            this.loadSports();
            // Use undefined instead of null
          },
          error: (err) => {
            console.error("Failed to update Sport:", err);
            this.notifyService.message("Failed to update Sport!");
          },
          complete: () => {           
            this.notifyService.message("Sports Data Updated");
            this.cdr.detectChanges();                   
          },
        });

    } else {
      this.sportsService.create(sport)
        .subscribe({
          next: (newSport: Sport) => {
            this.sports.push(newSport);
            this.notifyService.message("Data Saved");

            this.sportsForm.controls['sportsName'].clearValidators();
            this.sportsForm.controls['sportsName'].updateValueAndValidity();

            this.sportsForm.reset();

            // Reload sports after adding a new one
            this.loadSports();
          },
          error: (err) => {
            this.notifyService.message("Failed to save Sport!");
          },
        });
    }
  }

  // Create and Edit CricketFormat

  isEditingCricketFormat: boolean = false;
  editingCricketFormatId: number | undefined;

  editCricketFormat(element: any) {
    this.isEditingCricketFormat = true;
    this.editingCricketFormatId = element.cricketFormatId;

    this.cricketFormatForm.patchValue({
      sportId: element.sportId,
      formatName: element.formatName,
    });
  }
  saveCricketFormat() {
    if (this.cricketFormatForm.invalid) return;

    const cricketFormat: CricketFormat = this.cricketFormatForm.value;

    if (this.isEditingCricketFormat) {
      // Include the cricketFormatId when updating
      cricketFormat.cricketFormatId = this.editingCricketFormatId;

      this.cricketFormateService.update(cricketFormat)
        .subscribe({
          next: (updatedCricketFormat: CricketFormat) => {
            const index = this.cricketFormats.findIndex(cf => cf.cricketFormatId === updatedCricketFormat.cricketFormatId);
            this.isEditingCricketFormat = false;
            this.editingCricketFormatId = undefined;
            this.cricketFormats[index] = updatedCricketFormat;

            // Notify success for update
            this.notifyService.message("Cricket Format Updated");
            this.cdr.detectChanges();

            // Reload cricket formats after updating
            this.loadCricketFormats();
          },
          error: (err) => {
            console.error("Failed to update Cricket Format:", err);
            this.notifyService.message("Failed to update Cricket Format!");
          },
          complete: () => {           
            this.notifyService.message("Cricket Format Updated");
            this.cdr.detectChanges();                   
          },
        });
    } else {
      // Include the sportId when creating
      cricketFormat.sportId = this.cricketFormatForm.controls['sportId'].value;

      this.cricketFormateService.create(cricketFormat)
        .subscribe({
          next: (newCricketFormat: CricketFormat) => {
            this.cricketFormats.push(newCricketFormat);

            // Notify success for create
            this.notifyService.message("Cricket Format Saved");

            this.cricketFormatForm.controls['sportId'].clearValidators();
            this.cricketFormatForm.controls['sportId'].updateValueAndValidity();

            this.cricketFormatForm.controls['formatName'].clearValidators();
            this.cricketFormatForm.controls['formatName'].updateValueAndValidity();

            this.cricketFormatForm.reset();

            // Reload cricket formats after adding a new one
            this.loadCricketFormats();
          },
          error: (err) => {
            this.notifyService.message("Failed to save Cricket Format!");
          },
        });
    }
  }


  // Create and Edit Categories

  isEditingCategory: boolean = false;
  editingCategoryId: number | undefined = undefined;

  editCategory(element: any) {
    this.isEditingCategory = true;
    this.editingCategoryId = element.categoryId ?? undefined;
    this.categoriesForm.patchValue({
      categoryName: element.categoryName,
      // Add other fields as needed
    });
  }

  saveCategory() {
    if (this.categoriesForm.invalid) return;

    const category: Category = this.categoriesForm.value;

    if (this.isEditingCategory) {
      // Include the categoryId when updating
      category.categoryId = this.editingCategoryId;

      this.categoryService.update(category)
        .subscribe({
          next: (updatedCategory: Category) => {
            this.loadCategories();
            const index = this.categories.findIndex(c => c.categoryId === updatedCategory.categoryId);
            this.isEditingCategory = false;
            this.editingCategoryId = undefined;
            this.categories[index] = updatedCategory;
            this.notifyService.message("Category Updated");
            this.cdr.detectChanges();

            this.loadCategories();
          },
          error: (err) => {
            console.error("Failed to update Category:", err);
            this.notifyService.message("Failed to update Category!");
          },
          complete: () => {
            
            this.notifyService.message("Category Updated");
            this.cdr.detectChanges();                   
          },
        });
    } else {
      this.categoryService.create(category)
        .subscribe({
          next: (newCategory: Category) => {
            this.categories.push(newCategory);
            this.notifyService.message("Category Saved");

            this.categoriesForm.controls['categoryName'].clearValidators();
            this.categoriesForm.controls['categoryName'].updateValueAndValidity();

            this.categoriesForm.reset();

            // Reload categories after adding a new one
            this.loadCategories();
          },
          error: (err) => {
            this.notifyService.message("Failed to save Category!");
          },
        });
    }
  }


  // Create and Edit Training Session

  isEditingTrainingSession: boolean = false;
  editingTrainingSessionId: number | undefined;

  editTrainingSession(trainingSession: TrainingSession) {
    this.isEditingTrainingSession = true;
    this.editingTrainingSessionId = trainingSession.trainingSessionId;

    this.trainingSessionForm.patchValue({

      title: trainingSession.title,
      sessionTime: trainingSession.sessionTime,
      description: trainingSession.description,
      coachId: trainingSession.coachId,
    });
  }

  saveTrainingSession() {
    if (this.trainingSessionForm.invalid) return;

    const newTrainingSession: TrainingSession = this.trainingSessionForm.value;

    if (this.isEditingTrainingSession) {
      // Include the training session id when updating
      newTrainingSession.trainingSessionId = this.editingTrainingSessionId;

      this.trainingSessionService.update(newTrainingSession)
        .subscribe({
          next: (updatedTrainingSession: TrainingSession) => {
            const index = this.trainingSessions.findIndex(ts => ts.trainingSessionId === updatedTrainingSession.trainingSessionId);
            this.isEditingTrainingSession = false;
            this.editingTrainingSessionId = undefined;
            this.trainingSessions[index] = updatedTrainingSession;
            this.notifyService.message("Training Session Updated");
            this.cdr.detectChanges();

            this.loadTrainingSessions();
          },
          error: (err) => {
            console.error("Failed to update Training Session:", err);
            this.notifyService.message("Failed to update Training Session!");
          },
          complete: () => {
            
            this.notifyService.message("Training Session Updated");
            this.cdr.detectChanges();                   
          },
        });
    } else {
      this.trainingSessionService.create(newTrainingSession)
        .subscribe({
          next: (createdTrainingSession: TrainingSession) => {
            this.trainingSessions.push(createdTrainingSession);
            this.notifyService.message("Training Session Saved");

            this.trainingSessionForm.controls['title'].clearValidators();
            this.trainingSessionForm.controls['title'].updateValueAndValidity();

            this.trainingSessionForm.controls['sessionTime'].clearValidators();
            this.trainingSessionForm.controls['sessionTime'].updateValueAndValidity();

            this.trainingSessionForm.controls['description'].clearValidators();
            this.trainingSessionForm.controls['description'].updateValueAndValidity();

            this.trainingSessionForm.controls['coachId'].clearValidators();
            this.trainingSessionForm.controls['coachId'].updateValueAndValidity();

            this.trainingSessionForm.reset();

            // Reload training sessions after adding a new one
            this.loadTrainingSessions();
          },
          error: (err) => {
            this.notifyService.message("Failed to save Training Session!");
          },
        });
    }
  }

  // Create and Edit PlayerRole

  isEditingPlayerRole: boolean = false;
  editingPlayerRoleId: number | undefined = undefined;

  editPlayerRole(element: any) {
    this.isEditingPlayerRole = true;
    this.editingPlayerRoleId = element.playerRoleId ?? undefined;
    this.playerRoleForm.patchValue({
      roleName: element.roleName,
    });
  }

  savePlayerRole() {
    if (this.playerRoleForm.invalid) return;

    const newPlayerRole: PlayerRole = this.playerRoleForm.value;

    if (this.isEditingPlayerRole) {

      // Include the player role id when updating
      newPlayerRole.playerRoleId = this.editingPlayerRoleId;

      this.playerRoleService.update(newPlayerRole)
        .subscribe({
          next: (updatedPlayerRole: PlayerRole) => {
            // Update the local array with the updated player role
            const index = this.playerRoles.findIndex(pr => pr.playerRoleId === updatedPlayerRole.playerRoleId);
            this.playerRoles[index] = updatedPlayerRole;

            this.isEditingPlayerRole = false;
            this.editingPlayerRoleId = undefined;

            this.notifyService.message("Player Role Updated");

            // Ensure that the latest data is loaded
            this.loadPlayerRoles();
          },
          error: (err) => {
            console.error("Failed to update Player Role:", err);
            this.notifyService.message("Failed to update Player Role!");
          },
          complete: () => {
            this.notifyService.message("Player Role Updated");
            this.cdr.detectChanges();
          },
        });
    } else {
      this.playerRoleService.create(newPlayerRole)
        .subscribe({
          next: (createdPlayerRole: PlayerRole) => {
            // Push the newly created player role to the local array
            this.playerRoles.push(createdPlayerRole);

            this.notifyService.message("Player Role Saved");
            this.playerRoleForm.controls['roleName'].clearValidators();
            this.playerRoleForm.controls['roleName'].updateValueAndValidity();
            // Reset the form
            this.resetPlayerRoleForm();

            // Ensure that the latest data is loaded
            this.loadPlayerRoles();
          },
          error: (err) => {
            this.notifyService.message("Failed to save Player Role!");
          },
          complete: () => {
            // Reset the form
            this.resetPlayerRoleForm();
          },
        });
    }
  }

  private resetPlayerRoleForm() {
    this.playerRoleForm.reset();
    this.cdr.detectChanges();
  }


  // Create and Edit Equipment

  isEditingEquipment: boolean = false;
  editingEquipmentId: number | undefined = undefined;

  editEquipment(element: any) {
    this.isEditingEquipment = true;
    this.editingEquipmentId = element.equipmentId ?? undefined;
    this.equipmentsForm.patchValue({
      equipmentName: element.equipmentName,
      trainingSessionId: element.trainingSessionId,
    });
  }

  saveEquipment() {
    if (this.equipmentsForm.invalid) return;

    const newEquipment: Equipment = this.equipmentsForm.value;

    if (this.isEditingEquipment) {
      newEquipment.equipmentId = this.editingEquipmentId;

      this.equipmentService.update(newEquipment)
        .subscribe({
          next: (updatedEquipment: Equipment) => {
            const index = this.equipments.findIndex(e => e.equipmentId === updatedEquipment.equipmentId);
            this.equipments[index] = updatedEquipment;

            this.isEditingEquipment = false;
            this.editingEquipmentId = undefined;

            this.notifyService.message("Equipment Updated");

            // Ensure that the latest data is loaded
            this.loadEquipments();
          },
          error: (err) => {
            console.error("Failed to update Equipment:", err);
            this.notifyService.message("Failed to update Equipment!");
          },
          complete: () => {
            
            this.notifyService.message("Equipment Updated"); 
            this.cdr.detectChanges();
                      
          },
        });
    } else {
      this.equipmentService.create(newEquipment)
        .subscribe({
          next: (createdEquipment: Equipment) => {
            this.equipments.push(createdEquipment);

            this.notifyService.message("Equipment Saved");
            this.equipmentsForm.controls['equipmentName'].clearValidators();
            this.equipmentsForm.controls['equipmentName'].updateValueAndValidity();

            this.equipmentsForm.controls['trainingSessionId'].clearValidators();
            this.equipmentsForm.controls['trainingSessionId'].updateValueAndValidity();

            // Reset the form
            this.resetEquipmentForm();

            this.loadEquipments();
          },
          error: (err) => {
            this.notifyService.message("Failed to save Equipment!");
          },
        });
    }
  }

  // Add this method to your component
  private resetEquipmentForm() {
    this.equipmentsForm.reset();
    this.cdr.detectChanges();
  }
// Create and Edit Coach Specializaton

isEditingCoachSpecialization: boolean = false;
editingCoachSpecializationId: number | undefined = undefined;

editCoachSpecialization(element: any) {
  this.isEditingCoachSpecialization = true;
  this.editingCoachSpecializationId = element.coachSpecializationId ?? undefined;
  this.coachSpecializatonsForm.patchValue({
    specializedIn: element.specializedIn,
    coachId: element.coachId,
  });
}

saveCoachSpecialization() {
  if (this.coachSpecializatonsForm.invalid) {
    // Handle form validation errors
    return;
  }

  const newCoachSpecialization: CoachSpecializaton = this.coachSpecializatonsForm.value;

  if (this.isEditingCoachSpecialization) {
    newCoachSpecialization.coachSpecializationId = this.editingCoachSpecializationId;

    this.coachSpecializatonService.update(newCoachSpecialization)
      .subscribe({
        next: (updatedCoachSpecialization: CoachSpecializaton) => {
          const index = this.coachSpecializatons.findIndex(cs => cs.coachSpecializationId === updatedCoachSpecialization.coachSpecializationId);
          this.coachSpecializatons[index] = updatedCoachSpecialization;

          this.isEditingCoachSpecialization = false;
          this.editingCoachSpecializationId = undefined;

          this.notifyService.message("Coach Specialization Updated");

          // Ensure that the latest data is loaded
          this.loadCoachSpecialization();
        },
        error: (err) => {
          console.error("Failed to update Coach Specialization:", err);
          this.notifyService.message("Failed to update Coach Specialization!");
        },
        complete: () => {
            
          this.notifyService.message("Coach Specialization Updated"); 
          this.cdr.detectChanges();                   
        },
      });
  } else {
    this.coachSpecializatonService.create(newCoachSpecialization)
      .subscribe({
        next: (createdCoachSpecialization: CoachSpecializaton) => {
          this.coachSpecializatons.push(createdCoachSpecialization);

          this.notifyService.message("Coach Specialization Saved");

          this.coachSpecializatonsForm.controls['specializedIn'].clearValidators();
          this.coachSpecializatonsForm.controls['specializedIn'].updateValueAndValidity();

          this.coachSpecializatonsForm.controls['coachId'].clearValidators();
          this.coachSpecializatonsForm.controls['coachId'].updateValueAndValidity();

          this.coachSpecializatonsForm.reset();

          // Ensure that the latest data is loaded
          this.loadCoachSpecialization();
        },
        error: (err) => {
          console.error("Failed to save Coach Specialization:", err);
          this.notifyService.message("Failed to save Coach Specialization!");
        },
      });
  }
}

// Add this method to your component
private resetCoachSpecializationForm() {
  this.coachSpecializatonsForm.reset();
  this.cdr.detectChanges();
}


  sportsDelete(sport: Sport) {
    this.matDialog.open(ConfirmDeleteComponent, {
      "width": "450px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.sportsService.delete(<number>sport.sportId)
            .subscribe({
              next: r => {
                this.dataSource.data = this.dataSource.data.filter(x => x.sportId != sport.sportId);
                this.cdr.detectChanges();

                this.loadSports();

              },
              error: err => {
                this.notifyService.message("Failed to delete");
                console.log(err.message || err);
              }
            });
        }
      });
  }

  equipmetDelete(equipment: Equipment) {
    this.matDialog.open(ConfirmDeleteComponent, {
      "width": "450px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.equipmentService.delete(<number>equipment.equipmentId)
            .subscribe({
              next: r => {
                this.equipmentsDataSource.data = this.equipmentsDataSource.data.filter(x => x.equipmentId != equipment.equipmentId);
                this.cdr.detectChanges();

                // Reload cricket formats after updating
                this.loadEquipments();

              },
              error: err => {
                this.notifyService.message("Failed to Equipment");
                console.log(err.message || err);
              }
            });
        }
      });
  }

  //Delete Cricket Format
  cricketFormatDelete(cricketFormat: CricketFormat) {
    this.matDialog.open(ConfirmDeleteComponent, {
      "width": "450px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.cricketFormateService.delete(<number>cricketFormat.cricketFormatId)
            .subscribe({
              next: r => {
                this.cricketFormatDataSource.data = this.cricketFormatDataSource.data.filter(x => x.cricketFormatId != cricketFormat.cricketFormatId);
                this.notifyService.message("Cricket Format  Deleted");

                this.cdr.detectChanges();
                this.loadCricketFormats();
              },
              error: err => {
                this.notifyService.message("Failed to delete");
                console.log(err.message || err);
              }
            });
        }
      });
  }
  CategoryDelete(category: Category) {
    this.matDialog.open(ConfirmDeleteComponent, {
      "width": "450px"
    }).afterClosed()
      .subscribe(confirm => {
        if (confirm) {
          this.categoryService.delete(<number>category.categoryId)
            .subscribe({
              next: r => {
                this.categoryDataSource.data = this.categoryDataSource.data.filter(x => x.categoryId != category.categoryId);
                this.notifyService.message("Category Deleted");

                this.cdr.detectChanges();

                this.loadCategories();
              },
              error: err => {
                this.notifyService.message("Failed to delete");
                console.log(err.message || err);
              }
            });
        }
      });
  }
  // Delete Training Session

  deleteTrainingSession(trainingSession: TrainingSession) {
    const trainingSessionId = trainingSession.trainingSessionId;

    if (trainingSessionId !== undefined) {
      this.matDialog.open(ConfirmDeleteComponent, {
        width: "450px",
      }).afterClosed()
        .subscribe(confirm => {
          if (confirm) {
            this.trainingSessionService.delete(trainingSessionId)
              .subscribe({
                next: () => {
                  // Update the local array by removing the deleted training session
                  this.trainingSessions = this.trainingSessions.filter(ts => ts.trainingSessionId !== trainingSessionId);
                  this.notifyService.message("Training Session Deleted");


                  this.loadTrainingSessions();
                },
                error: (err) => {
                  this.notifyService.message("Failed to delete Training Session");
                  console.log(err.message || err);
                }
              });
          }
        });
    } else {
      console.error('Training Session Id is undefined');
    }
  }
  deletePlayerRole(playerRole: PlayerRole) {
    const playerRoleId = playerRole.playerRoleId;

    if (playerRoleId !== undefined) {
      this.matDialog.open(ConfirmDeleteComponent, {
        width: "450px",
      }).afterClosed()
        .subscribe(confirm => {
          if (confirm) {
            this.playerRoleService.delete(playerRoleId)
              .subscribe({
                next: () => {
                  // Update the local array by removing the deleted player role
                  this.playerRoles = this.playerRoles.filter(pr => pr.playerRoleId !== playerRoleId);
                  this.notifyService.message("Player Role Deleted");

                  // Ensure that the latest data is loaded
                  this.loadPlayerRoles();
                },
                error: (err) => {
                  this.notifyService.message("Failed to delete Player Role");
                  console.log(err.message || err);
                }
              });
          }
        });
    } else {
      console.error('Player Role Id is undefined');
    }
  }
  deleteCoachSpecialization(coachSpecialization: CoachSpecializaton) {
    const coachSpecializationId = coachSpecialization.coachSpecializationId;

    if (coachSpecializationId !== undefined) {
      this.matDialog.open(ConfirmDeleteComponent, {
        width: "450px",
      }).afterClosed()
        .subscribe(confirm => {
          if (confirm) {
            this.coachSpecializatonService.delete(coachSpecializationId)
              .subscribe({
                next: () => {
                  
                  this.coachSpecializatons = this.coachSpecializatons.filter(pr => pr.coachSpecializationId !== coachSpecializationId);
                  this.notifyService.message("Coach Specializatons Deleted");

                  this.loadCoachSpecialization();
                },
                error: (err) => {
                  this.notifyService.message("Failed to delete Coach Specializatons");
                  console.log(err.message || err);
                }
              });
          }
        });
    } 
    else {
      console.error('Coach Specializatons Id is undefined');
    }
  }

  ngOnInit(): void {
    this.loadSports();
    this.loadCricketFormats();
    this.loadCategories();
    this.loadTrainingSessions();
    this.loadPlayerRoles();
    this.loadEquipments();
    this.loadCoachSpecialization();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sportsSort;
    this.dataSource.paginator = this.sportsPaginator;

    this.cricketFormatDataSource.sort = this.cricketFormatsSort;
    this.cricketFormatDataSource.paginator = this.cricketFormatsPaginator;

    this.categoryDataSource.sort = this.categoriesSort;
    this.categoryDataSource.paginator = this.categoriesPaginator;

    this.trainingSessionDataSource.sort = this.trainingSessionSort;
    this.trainingSessionDataSource.paginator = this.trainingSessionPaginator;

    this.playerRolesDataSource.sort = this.playerRolesort;
    this.playerRolesDataSource.paginator = this.playerRolePaginator;

    this.equipmentsDataSource.sort = this.equipmentSort;
    this.equipmentsDataSource.paginator = this.equipmentPaginator;

    this.coachSpecializatonDataSource.sort = this.coachSpecializatonsSort;
    this.coachSpecializatonDataSource.paginator = this.coachSpecializatonsPaginator;
  }

  private setupTable(dataSource: MatTableDataSource<any>, sort: MatSort | undefined, paginator: MatPaginator | undefined): void {
    if (sort) {
      dataSource.sort = sort;
    }
    if (paginator) {
      dataSource.paginator = paginator;
    }
  }

  loadSports() {
    this.sportsService.getSports().subscribe({
      next: r => {
        this.sports = r;
        this.dataSource.data = this.sports;
        // this.dataSource.sort = this.sportsSort;
        // this.dataSource.paginator = this.sportsPaginator;
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Sport!");
      }
    });
  }

  loadCricketFormats() {
    this.cricketFormateService.getCricketFormats().subscribe({
      next: r => {
        console.log(r);
        this.cricketFormats = r;
        this.cricketFormatDataSource.data = this.cricketFormats;
        // this.cricketFormatDataSource.sort = this.cricketFormatsSort;
        // this.cricketFormatDataSource.paginator = this.cricketFormatsPaginator;
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Cricket Formats data!");
      },
    });
  }

  loadCategories() {
    this.categoryService.getCategories().subscribe({
      next: r => {
        this.categories = r;
        this.categoryDataSource.data = this.categories;
        this.categoryDataSource.sort = this.categoriesSort;
        // this.categoryDataSource.paginator = this.categoriesPaginator;
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Categories!");
      }
    });
  }
  loadTrainingSessions() {
    this.trainingSessionService.getTrainingSessions().subscribe({
      next: r => {
        this.trainingSessions = r;
        this.trainingSessionDataSource.data = this.trainingSessions;
        // this.trainingSessionDataSource.sort = this.categoriesSort;
        // this.trainingSessionDataSource.paginator = this.categoriesPaginator;

      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Trainig Session!");
      }
    });
    this.coachService.getCoaches().subscribe({
      next: r => {
        this.coaches = r;
        this.coachDataSource.data = this.coaches;

      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Coach data!");
      }
    });
  }
  loadPlayerRoles() {
    this.playerRoleService.getPlayerRoles().subscribe({
      next: r => {
        this.playerRoles = r;
        this.playerRolesDataSource.data = this.playerRoles;
        // this.dataSource.sort = this.sportsSort;
        // this.dataSource.paginator = this.sportsPaginator;
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Player Roles!");
      }
    });
  }
  loadEquipments() {
    this.equipmentService.getEquipments().subscribe({
      next: r => {
        this.equipments = r;
        this.equipmentsDataSource.data = this.equipments;
        // this.dataSource.sort = this.sportsSort;
        // this.dataSource.paginator = this.sportsPaginator;
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Equipments!");
      }
    });
  }
  loadCoachSpecialization() {
    this.coachSpecializatonService.getCoachSpecializatons().subscribe({
      next: r => {
        this.coachSpecializatons = r;
        this.coachSpecializatonDataSource.data = this.coachSpecializatons;
       
      },
      error: err => {
        console.log(err.message || err);
        this.notifyService.message("Failed to load Coach Specializatons!");
      }
    });
  }
}