import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectionPanelListComponent } from './selection-panel-list.component';

describe('SelectionPanelListComponent', () => {
  let component: SelectionPanelListComponent;
  let fixture: ComponentFixture<SelectionPanelListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SelectionPanelListComponent]
    });
    fixture = TestBed.createComponent(SelectionPanelListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
