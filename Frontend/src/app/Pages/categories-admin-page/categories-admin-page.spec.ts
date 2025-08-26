import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoriesAdminPage } from './categories-admin-page';

describe('CategoriesAdminPage', () => {
  let component: CategoriesAdminPage;
  let fixture: ComponentFixture<CategoriesAdminPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CategoriesAdminPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategoriesAdminPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
