import React, { useState, useEffect } from 'react';
import { Input, Card, CardHeader, Divider, CardBody, Button, CircularProgress } from "@nextui-org/react"
import { useForm } from 'react-hook-form';
import { useUserStore } from '../../Store/usersStore';
import { useNavigate } from 'react-router-dom';
import InformationModal from '../../Components/InformationModal';
const Register = () => {
    const { 
      register, 
      handleSubmit, 
      watch, 
      formState: { errors }
    } = useForm();
    const navigate = useNavigate();
    const [open, setOpen] = useState(false);
    const { 
      registerIsLoading,
      registerIsError,
      registerUser
    } = useUserStore((state) => state);

    useEffect(() => {
      if(registerIsLoading || registerIsError)
        setOpen(true)
      
      }, [registerIsLoading, registerIsError])

    const onSubmit = (e) => {
        let data = {
            username: e.username,
            password: e.password,
            email: e.email
        };

        registerUser(data);
        navigate('/login');
    }

    return (
    <div className="flex items-center justify-center min-h-screen bg-softwhite">
      <InformationModal open={open} setOpen={setOpen} title='Register'>
        {registerIsLoading && <CircularProgress />}
        {registerIsError && <p>Error!</p>}
      </InformationModal>
      <form className="w-full max-w-md" onSubmit={handleSubmit(onSubmit)}>
        <Card>
          <CardHeader className="flex items-center justify-center">
            <h1 className="text-2xl font-bold">Sign Up</h1>
          </CardHeader>
          <Divider />
          <CardBody>
            <div className="w-full flex flex-col items-center justify-center">
              <Input 
                className='pt-1 pb-1'
                label="Username"
                placeholder='user123'
                color= {errors.username ? 'danger' : ''}
                {...register("username", { required: true })} 
              />
              <Input 
                className='pt-1 pb-1'
                label="Email"
                placeholder='email123@gmail.com'
                color={errors.email ? 'danger' : ''}
                {...register("email", { required: true })} 
              />
              <Input
                className='pt-1 pb-1'
                type="password" 
                label="Password"
                placeholder='123pass123'
                color={errors.password ? 'danger' : ''}
                {...register("password", {
                required: true
                })}
              />
              <Input
                className='pt-1 pb-1'
                type="password" 
                label="Confirm Password"
                placeholder='123pass123'
                color={errors.confirm_password ? 'danger' : ''}
                {...register("confirm_password", {
                required: true,
                validate: (val) => {
                    if (watch('password') != val) {
                    return "Your passwords do no match";
                    }
                },
                })}
              />
              <Button type="submit" color="success" className="p-5 mt-1 font-bold text-white">Register</Button>
            </div>
          </CardBody>
        </Card>
      </form>
    </div>
  );
}

export default Register