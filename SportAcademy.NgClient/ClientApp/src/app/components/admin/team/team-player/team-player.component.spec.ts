import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamPlayerComponent } from './team-player.component';

describe('TeamPlayerComponent', () => {
  let component: TeamPlayerComponent;
  let fixture: ComponentFixture<TeamPlayerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TeamPlayerComponent]
    });
    fixture = TestBed.createComponent(TeamPlayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
