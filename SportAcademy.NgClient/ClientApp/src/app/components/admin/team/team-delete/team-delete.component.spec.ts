import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamDeleteComponent } from './team-delete.component';

describe('TeamDeleteComponent', () => {
  let component: TeamDeleteComponent;
  let fixture: ComponentFixture<TeamDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TeamDeleteComponent]
    });
    fixture = TestBed.createComponent(TeamDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
