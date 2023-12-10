import { Button, Card, CardBody, CardHeader, CircularProgress, Divider, Input } from "@nextui-org/react"
import { useEffect, useState } from "react";
import { useForm } from 'react-hook-form'
import { useNavigate } from "react-router-dom";
import { useUserStore } from '../../Store/usersStore.jsx';
import InformationModal from '../../Components/InformationModal/index.jsx'

function Login() {
  const { 
    register, 
    handleSubmit, 
    watch,
    formState: { errors }
  } = useForm();
  const [open, setOpen] = useState(false);
  const { 
    changePasswordIsLoading,
    changePasswordIsError, 
    changePassword
  } = useUserStore((state) => state);
  const navigate = useNavigate();

  useEffect(() => {
    if(changePasswordIsLoading || changePasswordIsError)
      setOpen(true)
    
  }, [changePasswordIsLoading, changePasswordIsError])

  const onSubmit = (e) => {
    const data = {
      actual: e.password,
      new: e.new_password
    }
    changePassword(data, navigate);
  }

  return (
    <div className="flex items-center justify-center min-h-screen bg-softwhite">
      <InformationModal open={open} setOpen={setOpen} title='Change password'>
        {changePasswordIsLoading && <CircularProgress />}
        {changePasswordIsError && <p>Error!</p>}
      </InformationModal>
      <form className="w-full max-w-md" onSubmit={handleSubmit(onSubmit)}>
        <Card>
          <CardHeader className="flex items-center justify-center">
            <h1 className="text-2xl font-bold">Change password</h1>
          </CardHeader>
          <Divider />
          <CardBody>
            <div className="w-full flex flex-col">
              <Input type="password" color={errors.password ? 'danger' : ''} label="Actual password" className="pt-2 pb-2 text-2xl" {...register("password", { required: "Required" })} />
              <Input type="password" color={errors.new_password ? 'danger' : ''} label="New password" className="pt-2 pb-2 text-2xl" {...register("new_password", { required: "Required" })} />
              <Input
                className='pt-2 pb-2'
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
              <Button type="submit" color="success" className="p-5 font-bold text-white">Change</Button>
            </div>
          </CardBody>
        </Card>
      </form>
    </div>
  )
}

export default Login