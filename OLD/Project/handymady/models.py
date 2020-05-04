from django.db import models


class Goods(models.Model):
    id_good = models.BigAutoField(primary_key=True)
    id_store = models.ForeignKey('Store', models.DO_NOTHING, db_column='id_store', blank=True, null=True)
    good_name = models.TextField(blank=True, null=True)
    description = models.TextField(blank=True, null=True)
    type = models.IntegerField(blank=True, null=True)
    amount = models.IntegerField(blank=True, null=True)
    cost = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'Goods'


class Purchase(models.Model):
    id_purchase = models.BigAutoField(primary_key=True)
    id_user = models.ForeignKey('Users', models.DO_NOTHING, db_column='id_user', blank=True, null=True)
    id_position = models.ForeignKey('PurchasePosition', models.DO_NOTHING, db_column='id_position', blank=True, null=True)
    date = models.DateField(blank=True, null=True)
    status = models.IntegerField(blank=True, null=True)
    full_price = models.IntegerField(blank=True, null=True)
    rate_store = models.IntegerField(blank=True, null=True)
    rate_good = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'Purchase'


class PurchasePosition(models.Model):
    id_position = models.BigAutoField(primary_key=True)
    id_good = models.ForeignKey(Goods, models.DO_NOTHING, db_column='id_good', blank=True, null=True)
    amount = models.IntegerField(blank=True, null=True)
    cost_one = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'Purchase_position'


class Sales(models.Model):
    id_sales = models.BigAutoField(primary_key=True)
    id_store = models.ForeignKey('Store', models.DO_NOTHING, db_column='id_store', blank=True, null=True)
    id_good = models.ForeignKey(Goods, models.DO_NOTHING, db_column='id_good', blank=True, null=True)
    sale_name = models.TextField(blank=True, null=True)
    description = models.TextField(blank=True, null=True)
    start = models.DateField(blank=True, null=True)
    stop = models.DateField(blank=True, null=True)
    percent = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'Sales'


class Store(models.Model):
    id_store = models.BigAutoField(primary_key=True)
    id_user = models.ForeignKey('Users', models.DO_NOTHING, db_column='id_user', blank=True, null=True)
    store_name = models.TextField(blank=True, null=True)
    description = models.TextField(blank=True, null=True)
    type = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'Store'


class Users(models.Model):
    id_user = models.BigAutoField(primary_key=True)
    login = models.TextField(blank=True, null=True)
    password = models.TextField(blank=True, null=True)
    email = models.TextField(blank=True, null=True)
    full_name = models.TextField(blank=True, null=True)
    address = models.TextField(blank=True, null=True)
    phone_number = models.BigIntegerField(blank=True, null=True)
    money_amount = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'Users'


class SubscribeList(models.Model):
    id_subscribe = models.BigAutoField(primary_key=True)
    id_user = models.ForeignKey(Users, models.DO_NOTHING, db_column='id_user', blank=True, null=True)
    id_store = models.ForeignKey(Store, models.DO_NOTHING, db_column='id_store', blank=True, null=True)
    sub_name_store = models.TextField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'subscribe_list'




class AuthGroup(models.Model):
    name = models.CharField(unique=True, max_length=150)

    class Meta:
        managed = False
        db_table = 'auth_group'


class AuthGroupPermissions(models.Model):
    group = models.ForeignKey(AuthGroup, models.DO_NOTHING)
    permission = models.ForeignKey('AuthPermission', models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_group_permissions'
        unique_together = (('group', 'permission'),)


class AuthPermission(models.Model):
    name = models.CharField(max_length=255)
    content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING)
    codename = models.CharField(max_length=100)

    class Meta:
        managed = False
        db_table = 'auth_permission'
        unique_together = (('content_type', 'codename'),)


class AuthUser(models.Model):
    password = models.CharField(max_length=128)
    last_login = models.DateTimeField(blank=True, null=True)
    is_superuser = models.BooleanField()
    username = models.CharField(unique=True, max_length=150)
    first_name = models.CharField(max_length=30)
    last_name = models.CharField(max_length=150)
    email = models.CharField(max_length=254)
    is_staff = models.BooleanField()
    is_active = models.BooleanField()
    date_joined = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'auth_user'


class AuthUserGroups(models.Model):
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)
    group = models.ForeignKey(AuthGroup, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_user_groups'
        unique_together = (('user', 'group'),)


class AuthUserUserPermissions(models.Model):
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)
    permission = models.ForeignKey(AuthPermission, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'auth_user_user_permissions'
        unique_together = (('user', 'permission'),)


class DjangoAdminLog(models.Model):
    action_time = models.DateTimeField()
    object_id = models.TextField(blank=True, null=True)
    object_repr = models.CharField(max_length=200)
    action_flag = models.SmallIntegerField()
    change_message = models.TextField()
    content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING, blank=True, null=True)
    user = models.ForeignKey(AuthUser, models.DO_NOTHING)

    class Meta:
        managed = False
        db_table = 'django_admin_log'


class DjangoContentType(models.Model):
    app_label = models.CharField(max_length=100)
    model = models.CharField(max_length=100)

    class Meta:
        managed = False
        db_table = 'django_content_type'
        unique_together = (('app_label', 'model'),)


class DjangoMigrations(models.Model):
    app = models.CharField(max_length=255)
    name = models.CharField(max_length=255)
    applied = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'django_migrations'


class DjangoSession(models.Model):
    session_key = models.CharField(primary_key=True, max_length=40)
    session_data = models.TextField()
    expire_date = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'django_session'

