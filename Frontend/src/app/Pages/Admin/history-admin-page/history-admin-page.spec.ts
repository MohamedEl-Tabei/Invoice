import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryAdminPage } from './history-admin-page';

describe('HistoryAdminPage', () => {
  let component: HistoryAdminPage;
  let fixture: ComponentFixture<HistoryAdminPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HistoryAdminPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HistoryAdminPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
