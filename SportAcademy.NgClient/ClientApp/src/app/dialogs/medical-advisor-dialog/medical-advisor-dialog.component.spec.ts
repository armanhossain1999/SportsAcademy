import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalAdvisorDialogComponent } from './medical-advisor-dialog.component';

describe('MedicalAdvisorDialogComponent', () => {
  let component: MedicalAdvisorDialogComponent;
  let fixture: ComponentFixture<MedicalAdvisorDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MedicalAdvisorDialogComponent]
    });
    fixture = TestBed.createComponent(MedicalAdvisorDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
